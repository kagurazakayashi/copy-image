using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using copy_image.Properties;


namespace copy_image
{
    public partial class Form1 : Form
    {
        public string imagePath = string.Empty;
        private int exitTime = 3000;
        int[] maxSize = new int[2] { -1, -1 };

        public Form1(string path)
        {
            InitializeComponent();
            imagePath = path;
            Text = path;
            // �O�����w���_ʼλ�Þ��ք�
            StartPosition = FormStartPosition.Manual;
            Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // �@ȡΞĻ�Ĺ����^���С�������������У�
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            // �O�����w��λ�Þ�ΞĻ�����½�
            int x = screen.Width - Width;
            int y = screen.Height - Height;
            // ����Ӌ�����λ��
            Location = new Point(x, y);
            exitTime = Settings.Default.AutoClose;
            if (exitTime <= 0)
            {
                WindowState = FormWindowState.Minimized;
            }
            timerStart.Enabled = true;
            if (Settings.Default.AutoSize)
            {
                maxSize[0] = (int)Settings.Default.AutoSizeW;
                maxSize[1] = (int)Settings.Default.AutoSizeH;
            }
        }

        private void timerExit_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timerStart_Tick(object sender, EventArgs e)
        {
            try
            {
                Image image = Image.FromFile(imagePath); // ��ָ��·���d��DƬ
                int[] imgSize = new int[2] { image.Width, image.Height };
                string sizeText = $"{imgSize[0]} x {imgSize[1]}";
                if (maxSize[0] > 0 && maxSize[1] > 0)
                {
                    int[] newSize = ImageResizer.ImageNewSize(image, maxSize[0], maxSize[1]);
                    if (newSize[0] != maxSize[0] || newSize[1] != maxSize[1])
                    {
                        sizeText = $"{newSize[0]} x {newSize[1]} (��ѹ�� {sizeText} )";
                        image = ImageResizer.ResizeImage(image, newSize[0], newSize[1]);
                        imgSize[0] = image.Width;
                        imgSize[1] = image.Height;
                    }
                }
                pictureBox1.Image = image;
                Clipboard.SetImage(image); // ���DƬ�}�u�����N��
                Text = $"{sizeText} - �Ѹ��� - " + imagePath;
                label1.Visible = false;
                if (exitTime <= 0)
                {
                    Application.Exit();
                }
                else if (exitTime <= 60)
                {
                    timerExit.Interval = exitTime * 1000;
                    timerExit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "ͼƬ����ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Application.Exit();
                }
                return;
            }
        }
    }
}
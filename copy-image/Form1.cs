using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using copy_image.Properties;
using System.Resources;

namespace copy_image
{
    public partial class Form1 : Form
    {
        public string imagePath = string.Empty;
        private int exitTime = 3000;
        int[] maxSize = new int[2] { -1, -1 };
        ResourceManager l;

        public Form1(string path)
        {
            InitializeComponent();
            l = new ResourceManager("copy_image.Resource", typeof(Form1).Assembly);
            imagePath = path;
            Text = path;
            // �O�����w���_ʼλ�Þ��ք�
            StartPosition = FormStartPosition.Manual;
            //Load += new EventHandler(Form1_Load);
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
            if (Settings.Default.ThemeStyle == 2 || (GlobalSettings.IsDarkModeEnabled && Settings.Default.ThemeStyle == 0))
            {
                applyDarkTheme();
            }
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

        private void applyDarkTheme()
        {
            BackColor = GlobalSettings.dark[0]; // ��ɫ����
            ForeColor = GlobalSettings.dark[1]; // �\��ɫǰ��
            // ���ÿ������Ԫ����Ҳ�����������ɫ
            foreach (Control c in Controls)
            {
                c.BackColor = GlobalSettings.dark[0];
                c.ForeColor = GlobalSettings.dark[1];
            }
        }

        private void timerExit_Tick(object sender, EventArgs e)
        {
            timerExit.Enabled = false;
            Application.Exit();
        }

        private void timerStart_Tick(object sender, EventArgs e)
        {
            timerStart.Enabled = false;
            try
            {
                Image image = Image.FromFile(imagePath); // ��ָ��·���d��DƬ
                int[] imgSize = new int[2] { image.Width, image.Height };
                string sizeText = $"{imgSize[0]} x {imgSize[1]}";
                if (maxSize[0] > 0 && maxSize[1] > 0)
                {
                    int[] newSize = ImageResizer.ImageNewSize(image, maxSize[0], maxSize[1]);
                    if (newSize[0] != imgSize[0] || newSize[1] != imgSize[1])
                    {
                        sizeText = $"{newSize[0]} x {newSize[1]} ({l.GetString("Compressed")} {sizeText} )";
                        image = ImageResizer.ResizeImage(image, newSize[0], newSize[1]);
                        imgSize[0] = image.Width;
                        imgSize[1] = image.Height;
                    }
                }
                pictureBox1.Image = image;
                Clipboard.SetImage(image); // ���DƬ�}�u�����N��
                Text = $"{sizeText} - {l.GetString("Copied")} - " + imagePath;
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
                string msg = ex.Message;
                if (msg.IndexOf("Out of memory") >= 0)
                {
                    msg = l.GetString("OutMemory");
                }
                if (MessageBox.Show(msg, l.GetString("CopyFailed"), MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Application.Exit();
                }
                return;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerStart.Enabled = false;
            timerExit.Enabled = false;
        }
    }
}
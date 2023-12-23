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

        public Form1()
        {
            InitializeComponent();
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
            if (exitTime > 60)
            {
                WindowState = FormWindowState.Minimized;
                exitTime = 1;
            }
            timerStart.Enabled = true;
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
                pictureBox1.Image = image;
                Clipboard.SetImage(image); // ���DƬ�}�u�����N��
                Text = "ͼƬ�ѳɹ����Ƶ������� - " + imagePath;
                label1.Visible = false;
                if (exitTime > 0 && exitTime <= 60)
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
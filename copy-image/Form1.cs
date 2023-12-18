using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace copy_image
{
    public partial class Form1 : Form
    {
        public string imagePath = string.Empty;
        public Form1()
        {
            InitializeComponent();
            // �O�����w���_ʼλ�Þ��ք�
            this.StartPosition = FormStartPosition.Manual;
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // �@ȡΞĻ�Ĺ����^���С�������������У�
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            // �O�����w��λ�Þ�ΞĻ�����½�
            int x = screen.Width - this.Width;
            int y = screen.Height - this.Height;
            // ����Ӌ�����λ��
            this.Location = new Point(x, y);
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
                timerExit.Enabled = true;
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
using System.Windows.Forms;

namespace copy_image
{
    public partial class Form1 : Form
    {
        string imagePath = string.Empty;
        public Form1(string[] args)
        {
            InitializeComponent();
            // �O�����w���_ʼλ�Þ��ք�
            this.StartPosition = FormStartPosition.Manual;
            this.Load += new EventHandler(Form1_Load);
            if (args.Length > 0)
            {
                imagePath = args[0];
            }
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

            if (imagePath == string.Empty)
            {
                if (MessageBox.Show("���ṩһ��ͼƬ·����Ϊ����", "��ָ����Ҫ�򿪵��ļ�", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Application.Exit();
                }
                return;
            }
            try
            {
                Image image = Image.FromFile(imagePath); // ��ָ��·������ͼƬ
                pictureBox1.Image = image;
                Clipboard.SetImage(image); // ��ͼƬ���Ƶ�������
                Text = "ͼƬ�ѳɹ����Ƶ������� - " + imagePath;
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

        private void timerExit_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
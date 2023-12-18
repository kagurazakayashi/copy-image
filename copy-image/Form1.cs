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
            // 設定窗體的開始位置為手動
            this.StartPosition = FormStartPosition.Manual;
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 獲取螢幕的工作區域大小（不包括工作列）
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            // 設定窗體的位置為螢幕的右下角
            int x = screen.Width - this.Width;
            int y = screen.Height - this.Height;
            // 應用計算出的位置
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
                Image image = Image.FromFile(imagePath); // 從指定路徑載入圖片
                pictureBox1.Image = image;
                Clipboard.SetImage(image); // 將圖片複製到剪貼簿
                Text = "图片已成功复制到剪贴板 - " + imagePath;
                label1.Visible = false;
                timerExit.Enabled = true;
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "图片复制失败", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Application.Exit();
                }
                return;
            }
        }
    }
}
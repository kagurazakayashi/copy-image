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
            // 設定窗體的開始位置為手動
            StartPosition = FormStartPosition.Manual;
            //Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 獲取螢幕的工作區域大小（不包括工作列）
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            // 設定窗體的位置為螢幕的右下角
            int x = screen.Width - Width;
            int y = screen.Height - Height;
            // 應用計算出的位置
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
            BackColor = GlobalSettings.dark[0]; // 暗色背景
            ForeColor = GlobalSettings.dark[1]; // 淺灰色前景
            // 對於每個控制元件，也應用相應的顏色
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
                Image image = Image.FromFile(imagePath); // 從指定路徑載入圖片
                int[] imgSize = new int[2] { image.Width, image.Height };
                string sizeText = $"{imgSize[0]} x {imgSize[1]}";
                if (maxSize[0] > 0 && maxSize[1] > 0)
                {
                    int[] newSize = ImageResizer.ImageNewSize(image, maxSize[0], maxSize[1]);
                    if (newSize[0] != imgSize[0] || newSize[1] != imgSize[1])
                    {
                        sizeText = $"{newSize[0]} x {newSize[1]} ({l.GetString("t.Compressed")} {sizeText} )";
                        image = ImageResizer.ResizeImage(image, newSize[0], newSize[1]);
                        imgSize[0] = image.Width;
                        imgSize[1] = image.Height;
                    }
                }
                pictureBox1.Image = image;
                Clipboard.SetImage(image); // 將圖片複製到剪貼簿
                Text = $"{sizeText} - {l.GetString("t.Copied")} - " + imagePath;
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
                    msg = l.GetString("t.OutMemory");
                }
                if (MessageBox.Show(msg, l.GetString("t.CopyFailed"), MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
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
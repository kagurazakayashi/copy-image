using copy_image.Properties;
using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace copy_image
{
    public partial class Form1 : Form
    {
        public string imagePath = string.Empty; // 圖片路徑
        private int exitTime = 3000; // 自動退出時間
        private int[] maxSize = new int[2] { -1, -1 }; // 尺寸限制
        private ResourceManager l; // 語言資源

        // 初始化一個窗體(Form)的實例。
        // 自定義的窗體構造函式，它接收一個路徑作為參數，並在窗體初始化時進行一系列設置，包括資源管理、窗體標題設置及啟動位置的設定。
        public Form1(string path)
        {
            InitializeComponent(); // 初始化窗體中的所有控件，這是設計器自動生成的方法，用於加載窗體的初始狀態。
            l = new ResourceManager("copy_image.Resource", typeof(Form1).Assembly); // 創建一個資源管理器的實例，用於從指定的資源檔案中讀取資源。這裡的 "copy_image.Resource" 指的是資源檔案的名稱。
            imagePath = path; // 將傳入的路徑參數賦值給 imagePath 變數，這個變數可能用於後續的圖片處理或顯示。
            Text = path; // 將窗體的標題設置為傳入的路徑，這樣可以直接在窗體的標題欄顯示當前處理的圖片路徑。
            StartPosition = FormStartPosition.Manual; // 設置窗體的啟動位置為手動，這意味著窗體的位置將基於位置屬性進行設置，而不是自動選擇位置。
        }

        // 當窗體加載（Form Load）事件發生時被調用
        // 首先計算窗體在螢幕上的位置，讓窗體顯示在螢幕的右下角。接著，根據應用程式的設定，決定是否應用深色主題，以及處理自動關閉和自動調整窗體大小的設定。
        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle screen = Screen.PrimaryScreen.WorkingArea; // 獲取主螢幕的工作區域大小，不包括系統任務欄和停靠窗口等。
            int x = screen.Width - Width; // 計算窗體在螢幕上的橫向位置，使其位於螢幕右側。
            int y = screen.Height - Height; // 計算窗體在螢幕上的縱向位置，使其位於螢幕底部。
            Location = new Point(x, y); // 設置窗體的位置，根據上面計算的 x 和 y 坐標。

            // 判斷是否應用深色主題。如果使用者設定的主題風格為 2，或當全局設定啟用深色模式且使用者設定的主題風格為 0 時，應用深色主題。
            if (Settings.Default.ThemeStyle == 2 || (GlobalSettings.IsDarkModeEnabled && Settings.Default.ThemeStyle == 0))
            {
                applyDarkTheme(); // 應用深色主題的方法。
            }

            exitTime = Settings.Default.AutoClose; // 從設定中讀取自動關閉時間。
            if (exitTime <= 0) // 如果自動關閉時間設定為 0 或負值，則將窗體最小化。
            {
                WindowState = FormWindowState.Minimized;
            }

            timerStart.Enabled = true; // 啟用計時器，可能用於開始某些異步操作或定時任務。

            // 判斷是否應用自動調整大小的設定。如果使用者開啟了自動調整大小的功能，則設定窗體的最大尺寸。
            if (Settings.Default.AutoSize)
            {
                maxSize[0] = (int)Settings.Default.AutoSizeW; // 設定窗體的最大寬度。
                maxSize[1] = (int)Settings.Default.AutoSizeH; // 設定窗體的最大高度。
            }
        }

        // 將窗體及其控件的主題設定為深色主題。
        // 這個方法通過設定窗體及其子控件的背景色和前景色，實現了深色主題的應用。它首先將窗體本身的背景色和前景色設定為深色主題相應的顏色，然後遍歷窗體中的所有控件，將每個控件的背景色和前景色也設定為深色主題的顏色。這樣可以確保窗體及其所有控件都能統一適應深色主題的設計，提供一致的用戶體驗。
        private void applyDarkTheme()
        {
            BackColor = GlobalSettings.dark[0]; // 設定窗體的背景顏色為全局設定中定義的深色主題背景顏色。
            ForeColor = GlobalSettings.dark[1]; // 設定窗體的前景顏色（通常是文字顏色）為全局設定中定義的深色主題前景顏色。

            foreach (Control c in Controls) // 遍歷窗體中的所有控件。
            {
                c.BackColor = GlobalSettings.dark[0]; // 將每個控件的背景顏色設定為深色主題的背景顏色。
                c.ForeColor = GlobalSettings.dark[1]; // 將每個控件的前景顏色設定為深色主題的前景顏色。
            }
        }

        // 用于响应定时器 timerExit 的 Tick 事件。当定时器触发时，这个方法会被调用。
        // 這個方法的作用是在定時器達到指定的時間間隔並觸發 Tick 事件時，停止定時器並關閉應用程式。首先，透過將 timerExit.Enabled 設定為 false 來停止定時器，防止它再次觸發。然後，呼叫 Application.Exit() 方法來關閉當前執行的應用程式，這包括關閉所有的窗體並釋放資源。這樣的機制常用於實現應用程式的自動關閉功能，例如，可能在某些情況下希望應用程式在執行了一定操作後自動退出。
        private void timerExit_Tick(object sender, EventArgs e)
        {
            timerExit.Enabled = false; // 停用定時器，阻止它再次觸發。
            Application.Exit(); // 呼叫 Application.Exit() 方法來關閉應用程式。這將關閉應用程式的所有窗體，並終止應用程式。
        }

        // 在一個計時器事件中讀取一個圖片檔案，根據設定的最大尺寸進行調整，然後將調整後的圖片顯示在一個PictureBox控件中，並複製到剪貼簿。如果設定了退出時間，則在滿足條件時退出應用程式。此外，這段代碼還處理了讀取圖片時可能出現的異常情況。
        private void timerStart_Tick(object sender, EventArgs e)
        {
            // 將計時器啟動設為關閉狀態，避免重複觸發。
            timerStart.Enabled = false;

            try
            {
                // 從檔案中讀取圖片。
                Image image = Image.FromFile(imagePath);
                // 初始化一個包含圖片原始寬度和高度的整數陣列。
                int[] imgSize = new int[2] { image.Width, image.Height };
                // 格式化顯示圖片尺寸的字串。
                string sizeText = $"{imgSize[0]} x {imgSize[1]}";

                // 檢查是否設定了最大尺寸限制，並且這些限制大於0。
                if (maxSize[0] > 0 && maxSize[1] > 0)
                {
                    // 計算新的圖片尺寸。
                    int[] newSize = ImageResizer.ImageNewSize(image, maxSize[0], maxSize[1]);
                    // 如果新尺寸與原始尺寸不同，則進行圖片壓縮。
                    if (newSize[0] != imgSize[0] || newSize[1] != imgSize[1])
                    {
                        // 更新顯示的尺寸資訊，包括壓縮後的尺寸。
                        sizeText = $"{newSize[0]} x {newSize[1]} ({l.GetString("Compressed")} {sizeText} )";
                        // 進行圖片尺寸調整。
                        image = ImageResizer.ResizeImage(image, newSize[0], newSize[1]);
                        // 更新圖片尺寸。
                        imgSize[0] = image.Width;
                        imgSize[1] = image.Height;
                    }
                }

                // 將調整後的圖片顯示在PictureBox控制項中。
                pictureBox1.Image = image;
                // 將圖片複製到剪貼簿。
                Clipboard.SetImage(image);
                // 更新視窗標題，顯示圖片尺寸、提示已複製，以及圖片路徑。
                Text = $"{sizeText} - {l.GetString("Copied")} - " + imagePath;
                // 隱藏提示標籤。
                label1.Visible = false;

                // 根據設定的退出時間，決定是否立即退出應用程式。
                if (exitTime <= 0)
                {
                    // 如果設定為立即退出，則關閉應用程式。
                    Application.Exit();
                }
                else if (exitTime <= 60)
                {
                    // 如果退出時間在60秒之內，設定退出計時器的時間間隔，並啟動計時器。
                    timerExit.Interval = exitTime * 1000;
                    timerExit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                // 處理圖片讀取或處理中發生的異常。
                string msg = ex.Message;
                // 如果異常信息包含"記憶體不足"，則使用自訂的錯誤信息。
                if (msg.IndexOf("Out of memory") >= 0)
                {
                    msg = l.GetString("OutMemory");
                }
                // 顯示錯誤信息，如果點擊確認則退出應用程式。
                if (MessageBox.Show(msg, l.GetString("CopyFailed"), MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Application.Exit();
                }
                return;
            }
        }

        // 關閉之前，停用名為timerStart和timerExit的兩個計時器，以確保這些計時器不會在表單關閉後繼續運行或觸發相應的事件。这是一个防止资源泄露和潜在错误的常见实践。
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 在表單關閉事件中，停用「開始」計時器。
            timerStart.Enabled = false;
            // 同時，也停用「退出」計時器。
            timerExit.Enabled = false;
        }

    }
}
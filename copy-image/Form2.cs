using copy_image.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace copy_image
{
    public partial class Form2 : Form
    {
        public string imagePath = string.Empty; // 圖片路徑
        private ResourceManager l; // 語言資源
        public string extName = ""; // 自動退出時間
        private AniEgg aniegg = null; // 彩蛋動畫
        private Size defaultSize; // 預設視窗尺寸
        private bool initOK = false; // 是否已完成初始化

        // 帶有一個參數的構造函數，這個參數path用於接收一個圖片的路徑。該構造函數首先調用InitializeComponent方法來初始化表單的控制項，然後創建一個ResourceManager實例來管理資源檔中的資源，這可以用於國際化和本地化。最後，它將傳入的圖片路徑賦值給imagePath成員變數，用於後續的圖片處理操作。
        public Form2(string path)
        {
            // 呼叫 InitializeComponent 方法來初始化表單控制項及其屬性。
            InitializeComponent();

            // 創建 ResourceManager 物件，用於從資源檔中加載語言資源。
            // "copy_image.Resource" 指定資源檔的名稱，typeof(Form2).Assembly 表示資源位於當前組件中。
            l = new ResourceManager("copy_image.Resource", typeof(Form2).Assembly);

            // 將傳入的路徑字符串賦值給 imagePath 變數，此變數用於存儲圖片的路徑。
            imagePath = path;
        }

        // 處理Form2載入時的事件，包括設定界面上各個控制項的初始狀態（如主題風格、語言選擇、自動關閉時間等），根據用戶的預設設定或系統設定進行界面調整，並準備一些必要的信息（如應用程式路徑、文件類型等）。
        private void Form2_Load(object sender, EventArgs e)
        {
            // 從資源檔讀取主題設定，並將其分割成字符串陣列。
            string themesT = l.GetString("Theme");
            string[] themes = new string[0];
            if (themesT != null)
            {
                themes = themesT.Split(',');
            }
            // 從資源檔讀取檔案瀏覽器擴展名。
            extName = l.GetString("ExplorerExt");
            // 將主題添加到主題選擇的下拉列表中。
            foreach (string theme in themes)
            {
                comboBoxThemeStyle.Items.Add(theme);
            }
            // 讀取支持的語言列表，並將它們添加到語言選擇的下拉列表中。
            themes = LanguageMgr.langList();
            foreach (string theme in themes)
            {
                comboBoxLanguage.Items.Add(theme);
            }
            // 根據設定檔案中保存的主題設定，選擇相應的主題。
            if (Settings.Default.ThemeStyle >= comboBoxThemeStyle.Items.Count)
            {
                comboBoxThemeStyle.SelectedIndex = 0;
            }
            else
            {
                comboBoxThemeStyle.SelectedIndex = Settings.Default.ThemeStyle;
            }
            // 如果選擇了深色主題或系統處於深色模式並且設定為跟隨系統，則應用深色主題。
            if (Settings.Default.ThemeStyle == 2 || (GlobalSettings.IsDarkModeEnabled && Settings.Default.ThemeStyle == 0))
            {
                applyDarkTheme();
            }
            // 自動設定語言並顯示當前語言。
            string showLang = LanguageMgr.autoSetLanguage(false, false)[2];
            showLang = LanguageMgr.langInfo(showLang);
            comboBoxLanguage.Text = showLang;
            // 如果圖片路徑不為空，則在標籤中顯示路徑無效的訊息。
            if (imagePath != string.Empty)
            {
                label1.Text += $"\n{imagePath} {l.GetString("t.NotValidPath")}";
            }
            // 設定自動關閉時間，並確保其在允許的範圍內。
            int autoClose = Settings.Default.AutoClose;
            if (autoClose < trackBarAutoClose.Minimum)
            {
                autoClose = trackBarAutoClose.Minimum;
            }
            else if (autoClose > trackBarAutoClose.Maximum)
            {
                autoClose = trackBarAutoClose.Maximum;
            }
            trackBarAutoClose.Value = autoClose;
            // 更新自動關閉時間的顯示。
            trackBarAutoClose_Scroll(sender, e);
            // 顯示當前執行檔的路徑。
            textBoxExePath.Text = Assembly.GetExecutingAssembly().Location.Replace(".dll", ".exe");
            // 如果設定檔案中有設定右鍵選單名稱，則顯示它。
            if (Settings.Default.MenuItemName.Length > 0)
            {
                textBoxShellMenuItemName.Text = Settings.Default.MenuItemName;
            }
            // 如果有設定檔案擴展名，則顯示它。
            if (Settings.Default.fileExtensions.Length > 0)
            {
                textBoxFileTypes.Text = Settings.Default.fileExtensions;
            }
            // 設定自動調整尺寸的最大寬度和高度，並確保它們在允許的範圍內。
            decimal[] maxSize = new decimal[2] { Settings.Default.AutoSizeW, Settings.Default.AutoSizeH };
            if (maxSize[0] < numericAutoSizeW.Minimum)
            {
                maxSize[0] = numericAutoSizeW.Minimum;
            }
            else if (maxSize[0] > numericAutoSizeW.Maximum)
            {
                maxSize[0] = numericAutoSizeW.Maximum;
            }
            if (maxSize[1] < numericAutoSizeH.Minimum)
            {
                maxSize[1] = numericAutoSizeH.Minimum;
            }
            else if (maxSize[1] > numericAutoSizeH.Maximum)
            {
                maxSize[1] = numericAutoSizeH.Maximum;
            }
            // 根據設定檔案中的設定，啟用或禁用自動調整尺寸的選項。
            checkBoxAutoSize.Checked = Settings.Default.AutoSize;
            numericAutoSizeW.Value = maxSize[0];
            numericAutoSizeH.Value = maxSize[1];
            numericAutoSizeW.Enabled = Settings.Default.AutoSize;
            numericAutoSizeH.Enabled = Settings.Default.AutoSize;
            // 記錄表單加載時的大小，用於後續的介面調整。
            defaultSize = Size;
            // 標記初始化已完成。
            initOK = true;
        }

        // 將應用程序的主題設定為暗色主題。它首先設定表單的背景色和前景色，然後遍歷表單上的所有控制元件，包括按鈕、下拉選單、文字框和數字調節框，將它們的背景色、前景色、樣式和邊框樣式調整為適合暗色主題的設定。此方法通過統一應用暗色主題的顏色和樣式，增強了應用程序在暗色模式下的視覺一致性和用戶體驗。
        private void applyDarkTheme()
        {
            // 設定表單背景顏色為暗色主題的背景色。
            BackColor = GlobalSettings.dark[0];
            // 設定表單前景顏色為暗色主題的前景色（通常是文字顏色）。
            ForeColor = GlobalSettings.dark[1];

            // 定義需要調整顏色的控制元件陣列。
            Control[] controlList = new Control[] { numericAutoSizeW, numericAutoSizeH, textBoxExePath, textBoxShellMenuItemName, textBoxFileTypes };
            // 定義按鈕陣列，以便統一設置其樣式。
            Button[] buttonList = new Button[] { buttonShellMenuItemStatus, buttonShellMenuItemAdd, buttonShellMenuItemRemove };
            // 定義下拉選單陣列，以便統一設置其樣式。
            ComboBox[] comboBoxList = new ComboBox[] { comboBoxLanguage, comboBoxThemeStyle };
            // 定義文字框陣列，以便統一設置其樣式。
            TextBox[] textBoxList = new TextBox[] { textBoxExePath, textBoxShellMenuItemName, textBoxFileTypes };
            // 定義數字調節框陣列，以便統一設置其樣式。
            NumericUpDown[] numericUpDownList = new NumericUpDown[] { numericAutoSizeW, numericAutoSizeH };

            // 遍歷表單上的所有控制元件，將它們的背景色和前景色設定為暗色主題的顏色。
            foreach (Control c in Controls)
            {
                c.BackColor = GlobalSettings.dark[0];
                c.ForeColor = GlobalSettings.dark[1];
            }
            // 遍歷特定控制元件陣列，將它們的背景色和前景色設定為暗色主題的顏色。
            foreach (Control c in controlList)
            {
                c.BackColor = GlobalSettings.dark[0];
                c.ForeColor = GlobalSettings.dark[1];
            }
            // 遍歷按鈕陣列，除了設定背景色和前景色，還設定其樣式為Flat。
            foreach (Button c in buttonList)
            {
                c.BackColor = GlobalSettings.dark[0];
                c.ForeColor = GlobalSettings.dark[1];
                c.FlatStyle = FlatStyle.Flat;
            }
            // 遍歷下拉選單陣列，設定其樣式為Flat。
            foreach (ComboBox c in comboBoxList)
            {
                c.FlatStyle = FlatStyle.Flat;
            }
            // 遍歷文字框陣列，設定其邊框樣式為單行。
            foreach (TextBox c in textBoxList)
            {
                c.BorderStyle = BorderStyle.FixedSingle;
            }
            // 遍歷數字調節框陣列，設定其邊框樣式為單行。
            foreach (NumericUpDown c in numericUpDownList)
            {
                c.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        // 處理滑動條（trackBarAutoClose）的滑動事件。當滑動條滑動時，會根據其值更新一個分組盒（groupBoxAutoClose）的標題，以顯示自動關閉的時間或信息，並在必要時更新設定值。
        private void trackBarAutoClose_Scroll(object sender, EventArgs e)
        {
            // 定義一個字串分隔符號
            string splitchar = ": ";
            // 從 groupBoxAutoClose 的文字中，使用分隔符號分割，並取得第一部分作為時間標題
            string timeTitle = groupBoxAutoClose.Text.Split(new string[] { splitchar }, StringSplitOptions.RemoveEmptyEntries)[0];
            // 獲取滑動條當前的值
            int val = trackBarAutoClose.Value;
            // 如果當前值是滑動條的最小值
            if (val == trackBarAutoClose.Minimum)
            {
                // 時間標題加上分隔符號和 labelAutoCloseInfo1 的文字
                timeTitle += splitchar + labelAutoCloseInfo1.Text;
            }
            // 如果當前值是滑動條的最大值
            else if (val == trackBarAutoClose.Maximum)
            {
                // 時間標題加上分隔符號和 labelAutoCloseInfo2 的文字
                timeTitle += splitchar + labelAutoCloseInfo2.Text;
            }
            // 否則，即當前值在最小值和最大值之間
            else
            {
                // 時間標題加上分隔符號、當前值和後綴（秒）
                timeTitle += splitchar + val.ToString() + " " + l.GetString("t.Seconds");
            }
            // 更新 groupBoxAutoClose 的文字為最新的時間標題
            groupBoxAutoClose.Text = timeTitle;
            // 如果當前值不等於預設設定值
            if (val != Settings.Default.AutoClose)
            {
                // 更新預設設定值為當前值
                Settings.Default.AutoClose = val;
            }
        }

        // 當窗體準備關閉時，會檢查是否存在 aniegg 對象，如果存在則停止其操作，並儲存應用程序的設定。
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 判斷 aniegg 是否不為 null，若不為 null 則執行 Stop 方法
            if (aniegg != null)
            {
                aniegg.Stop();
            }
            // 儲存設定至設定檔
            Settings.Default.Save();
        }

        // 當指定的文本框內容變更時，會更新相應的設定值，以保持設定的即時更新。
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // 將 textBoxShellMenuItemName 文本框的文字去除首尾空格後，設定為 MenuItemName 的設定值
            Settings.Default.MenuItemName = textBoxShellMenuItemName.Text.Trim();
        }

        // 當指定的文本框內容變更時，會更新相應的設定值，以保持設定的即時更新。
        private void textBoxFileTypes_TextChanged(object sender, EventArgs e)
        {
            // 將 textBoxFileTypes 文本框的文字去除首尾空格後，設定為 fileExtensions 的設定值
            Settings.Default.fileExtensions = textBoxFileTypes.Text.Trim();
        }


        // 當按下「新增右键菜单项」按钮时触发的事件处理方法。通过用户界面允许用户为特定的文件类型添加右键菜单项的功能。代码涵盖了从用户界面获取数据、处理数据、调用方法添加菜单项以及处理可能出现的错误的逻辑。
        private void buttonShellMenuItemAdd_Click(object sender, EventArgs e)
        {
            // 從textBoxExePath文字框中獲取應用程序路徑，並去除首尾空白
            string path = textBoxExePath.Text.Trim();
            // 從textBoxShellMenuItemName文字框中獲取要新增的右键菜单项名稱，並去除首尾空白
            string name = textBoxShellMenuItemName.Text.Trim();
            // 從textBoxFileTypes文字框中獲取文件類型，用逗号分隔後轉換成字符串數組
            string[] fileTypes = textBoxFileTypes.Text.Trim().Split(',');
            // 定義一個字符串列表來存储操作結果信息
            List<string> infos = new List<string>();

            // 遍歷所有文件類型
            for (int i = 0; i < fileTypes.Length; i++)
            {
                // 獲取當前循环的文件類型
                string ftype = fileTypes[i];
                // 嘗試为當前文件類型添加右键菜单项，若添加失败則进入錯誤處理
                if (!ShellMenuItemMgr.AddContextMenu(ftype, path, name))
                {
                    // 彈出消息框提示添加失败，提供中止、重試及忽略三个選項，並显示錯誤圖標
                    DialogResult result = MessageBox.Show($".{ftype} {l.GetString("t.FailedAddMenu")}{l.GetString("t.TryAdmin")}", extName, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    // 根据用户選擇处理
                    if (result == DialogResult.Retry)
                    {
                        // 若選擇重試，则當前索引減1，重新進行此次循环
                        i--;
                        continue;
                    }
                    else if (result == DialogResult.Abort)
                    {
                        // 若選擇中止，则記錄此文件類型添加失败的信息，並退出循环
                        infos.Add($".{ftype} {l.GetString("t.AddFail")}");
                        break;
                    }
                    else if (result == DialogResult.Ignore)
                    {
                        // 若選擇忽略，则記錄此文件類型添加失败的信息，继续下一次循环
                        infos.Add($".{ftype} {l.GetString("t.AddFail")}");
                        continue;
                    }
                }
                // 若添加成功，则記錄此文件類型添加成功的信息
                infos.Add($".{ftype} {l.GetString("t.AddOK")}");
            }
            // 將所有操作結果信息使用换行符連接成一個字符串，然後通過消息框顯示给用户
            MessageBox.Show(string.Join(Environment.NewLine, infos.ToArray()), extName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // 當點擊移除選單項目的按鈕時觸發的事件處理器。通過遍歷用戶指定的文件類型，嘗試移除每種文件類型相關的右鍵選單項目，並根據操作結果向用戶反饋相應的訊息。
        private void buttonShellMenuItemRemove_Click(object sender, EventArgs e)
        {
            // 從文本框中讀取用戶輸入的文件類型，去掉首尾空格後，根據逗號分割成陣列
            string[] fileTypes = textBoxFileTypes.Text.Trim().Split(',');
            // 創建一個列表來存儲操作結果的信息
            List<string> infos = new List<string>();
            // 遍歷用戶輸入的每一種文件類型
            for (int i = 0; i < fileTypes.Length; i++)
            {
                // 獲取當前循環到的文件類型
                string ftype = fileTypes[i];
                // 嘗試移除當前文件類型的右鍵選單項目，如果移除失敗
                if (!ShellMenuItemMgr.RemoveContextMenu(ftype))
                {
                    // 顯示錯誤訊息框，提供中止、重試、忽略的選項，並記錄用戶的選擇
                    DialogResult result = MessageBox.Show($".{ftype} {l.GetString("t.FailedRemoveMenu")}{l.GetString("t.TryAdmin")}", extName, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    // 如果用戶選擇重試
                    if (result == DialogResult.Retry)
                    {
                        // 索引遞減，再次嘗試當前的文件類型
                        i--;
                        continue;
                    }
                    // 如果用戶選擇中止
                    else if (result == DialogResult.Abort)
                    {
                        // 將當前文件類型的移除失敗信息加入列表中，並跳出循環
                        infos.Add($".{ftype} {l.GetString("t.RmFail")}");
                        break;
                    }
                    // 如果用戶選擇忽略
                    else if (result == DialogResult.Ignore)
                    {
                        // 將當前文件類型的移除失敗信息加入列表，繼續下一次循環
                        infos.Add($".{ftype} {l.GetString("t.RmFail")}");
                        continue;
                    }
                }
                // 如果移除成功，將成功信息加入列表
                infos.Add($".{ftype} {l.GetString("t.RmOK")}");
            }
            // 最後將所有的操作結果顯示在訊息框中
            MessageBox.Show(string.Join(Environment.NewLine, infos.ToArray()), extName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 按鈕時觸發。從一個文字輸入框中讀取用戶輸入的檔案類型（逗號分隔），然後檢查這些檔案類型在系統上下文選單中是否已經存在。對於每個檔案類型，根據它們是否存在，將相應的狀態信息添加到一個列表中。最後，這些狀態信息將被顯示在一個消息框中。
        private void buttonShellMenuItemStatus_Click(object sender, EventArgs e)
        {
            // 將 textBoxFileTypes 文字方塊中的文字去除前後空格後，依照逗號分割成陣列。
            string[] fileTypes = textBoxFileTypes.Text.Trim().Split(',');
            // 創建一個字串列表，用於存儲檔案類型的狀態資訊。
            List<string> infos = new List<string>();
            // 使用 for 迴圈遍歷所有的檔案類型。
            for (int i = 0; i < fileTypes.Length; i++)
            {
                // 取得當前迭代的檔案類型。
                string ftype = fileTypes[i];
                // 檢查系統上下文選單中是否已存在該檔案類型的項目。
                if (ShellMenuItemMgr.CheckContextMenuExists(ftype))
                {
                    // 如果存在，則添加帶有存在訊息的檔案類型到 infos 列表中。
                    infos.Add($".{ftype} {l.GetString("t.ExistsYes")}");
                }
                else
                {
                    // 如果不存在，則添加帶有不存在訊息的檔案類型到 infos 列表中。
                    infos.Add($".{ftype} {l.GetString("t.ExistsNo")}");
                }
            }
            // 顯示一個訊息框，內容為所有檔案類型的存在狀態，每種檔案類型的狀態佔一行。
            MessageBox.Show(string.Join(Environment.NewLine, infos.ToArray()), extName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // 當自動調整大小的勾選方塊狀態變更時觸發的事件
        private void checkBoxAutoSize_CheckedChanged(object sender, EventArgs e)
        {
            // 如果初始化完成
            if (initOK)
            {
                // 將設定中的自動調整大小屬性設為勾選方塊的狀態
                Settings.Default.AutoSize = checkBoxAutoSize.Checked;
            }
            // 根據勾選方塊是否被勾選，啟用或禁用寬度和高度的數值輸入控件
            numericAutoSizeW.Enabled = checkBoxAutoSize.Checked;
            numericAutoSizeH.Enabled = checkBoxAutoSize.Checked;
        }

        // 當自動調整大小的寬度值變更時觸發的事件
        private void numericAutoSizeW_ValueChanged(object sender, EventArgs e)
        {
            // 如果初始化完成
            if (initOK)
            {
                // 更新設定中的自動調整大小的寬度值
                Settings.Default.AutoSizeW = numericAutoSizeW.Value;
            }
        }

        // 當自動調整大小的高度值變更時觸發的事件
        private void numericAutoSizeH_ValueChanged(object sender, EventArgs e)
        {
            // 如果初始化完成
            if (initOK)
            {
                // 更新設定中的自動調整大小的高度值
                Settings.Default.AutoSizeH = numericAutoSizeH.Value;
            }
        }

        // 當主題樣式選擇框選擇項目改變時觸發的事件
        private void comboBoxThemeStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 如果初始化完成
            if (initOK)
            {
                // 更新設定中的主題樣式為選擇框當前選中的索引
                Settings.Default.ThemeStyle = comboBoxThemeStyle.SelectedIndex;
            }
        }

        // 當語言選擇框選擇項目改變時觸發的事件
        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 如果初始化完成
            if (initOK)
            {
                // 更新設定中的預設語言為選擇框當前選中的語言
                Settings.Default.DefaultLanguage = LanguageMgr.langInfo(comboBoxLanguage.Text);
                // 關閉當前窗體
                Close();
                // 重新啟動應用程序
                Application.Restart();
                // 結束當前進程
                Environment.Exit(0);
            }
        }

        // 當連結標籤被點擊時觸發的事件
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 啟動一個進程打開指定的URL
            Process.Start(new ProcessStartInfo()
            {
                FileName = "https://github.com/kagurazakayashi/copy-image",
                UseShellExecute = true
            });
        }

        // 每當定時器觸發時執行的事件
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 如果動畫蛋對象存在
            if (aniegg != null)
            {
                // 呼叫動畫蛋的Tick方法，進行動畫處理
                aniegg.Tick();
            }
        }

        // 當點擊 pictureBox1 時觸發的事件處理方法
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // 檢查 aniegg 是否為 null，若為 null 則進行初始化設定
            if (aniegg == null)
            {
                // 設置窗體狀態為正常大小
                WindowState = FormWindowState.Normal;
                // 設置窗體大小為預設值
                Size = defaultSize;
                // 設置窗體的最大大小為預設值
                MaximumSize = defaultSize;
                // 關閉最大化按鈕
                MaximizeBox = false;
                // 初始化 aniegg 物件，並傳入目前視窗的高度、pictureBox1 和 timer1 作為參數
                aniegg = new AniEgg(ClientSize.Height, pictureBox1, timer1);
            }
        }

        // 當在 pictureBox1 上按下滑鼠按鍵時觸發的事件處理方法
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // 檢查 aniegg 是否已經被實例化，若已實例化則呼叫 Down 方法
            if (aniegg != null)
            {
                aniegg.Down();
            }
        }

        // 當在 pictureBox1 上移動滑鼠時觸發的事件處理方法
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // 檢查 aniegg 是否已經被實例化，若已實例化則呼叫 Move 方法
            if (aniegg != null)
            {
                aniegg.Move();
            }
        }

        // 當在 pictureBox1 上釋放滑鼠按鍵時觸發的事件處理方法
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // 檢查 aniegg 是否已經被實例化，若已實例化則呼叫 Up 方法
            if (aniegg != null)
            {
                aniegg.Up();
            }
        }

    }
}

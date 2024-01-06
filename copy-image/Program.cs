using System;
using System.IO;
using System.Windows.Forms;

namespace copy_image
{
    internal static class Program
    {
        [STAThread] // 指定主程序執行為單一執行緒的應用程式模型
        static void Main(string[] args) // 主程式進入點
        {
            ApplicationConfiguration.Initialize(); // 初始化應用程式配置
            Application.SetHighDpiMode(HighDpiMode.SystemAware); // 設定高DPI模式為系統感知模式
            UpdateDarkModeStatus(); // 更新深色模式狀態

            LanguageMgr.autoSetLanguage(); // 自動設定語言

            if (args.Length > 0 && IsValidFilePath(args[0])) // 如果命令列參數存在且第一個參數是有效的檔案路徑
            {
                Form1 form1 = new Form1(args[0]); // 創建Form1的實例，並傳入參數作為初始化參數
                Application.Run(form1); // 執行form1
            }
            else
            {
                Application.EnableVisualStyles(); // 啟用視覺樣式
                Application.SetCompatibleTextRenderingDefault(false); // 設定預設的文字呈現方式
                if (args.Length > 0) // 如果命令列參數存在
                {
                    Application.Run(new Form2(args[0])); // 創建Form2的實例，並傳入參數作為初始化參數，然後執行
                }
                else
                {
                    Application.Run(new Form2(string.Empty)); // 創建Form2的實例，不傳入初始化參數，然後執行
                }
            }
        }

        // 更新深色模式狀態的方法
        public static void UpdateDarkModeStatus()
        {
            var registryValue = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1); // 從登錄中獲取深色模式的狀態
            GlobalSettings.IsDarkModeEnabled = registryValue != null && registryValue.Equals(0); // 設定全域設定中的深色模式是否啟用
        }

        // 檢查檔案路徑是否有效的方法
        public static bool IsValidFilePath(string path)
        {
            return File.Exists(path) || Directory.Exists(path); // 檢查檔案或目錄是否存在
        }

    }
}
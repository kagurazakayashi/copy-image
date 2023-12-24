using System;
using System.IO;
using System.Windows.Forms;

namespace copy_image
{
    internal static class Program
    {
        [STAThread] // 設定單執行緒單元(STA)模式，因為剪貼簿類需要它
        static void Main(string[] args)
        {
            //ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            if (args.Length > 0 && IsValidFilePath(args[0]))
            {
                Form1 form1 = new Form1(args[0]);
                Application.Run(form1);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (args.Length > 0)
                {
                    Application.Run(new Form2(args[0]));
                }
                else
                {
                    Application.Run(new Form2(string.Empty));
                }
            }
        }

        public static bool IsValidFilePath(string path)
        {
            return File.Exists(path) || Directory.Exists(path);
        }
    }
}
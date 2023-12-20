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
            if (args.Length > 0 && IsValidFilePath(args[0]))
            {
                Form1 form1 = new Form1();
                form1.imagePath = args[0];
                Application.Run(form1);
            }
            else
            {
                Form2 form2 = new Form2();
                if (args.Length > 0)
                {
                    form2.imagePath = args[0];
                }
                Application.Run(new Form2());
            }
        }

        public static bool IsValidFilePath(string path)
        {
            return File.Exists(path) || Directory.Exists(path);
        }
    }
}
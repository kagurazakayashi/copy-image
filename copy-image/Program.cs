using System;
using System.IO;
using System.Windows.Forms;

namespace copy_image
{
    internal static class Program
    {
        [STAThread] // �O���Έ��оw��Ԫ(STA)ģʽ�������N�����Ҫ��
        static void Main(string[] args)
        {
            //ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            UpdateDarkModeStatus();
            if (args.Length > 0 && IsValidFilePath(args[0]))
            {
                Form1 form1 = new Form1(args[0]);
                Application.Run(form1);
            }
            else
            {
                // ���ˈ����ٶȣ�ֻ���O��ҕ���������^
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

        public static void UpdateDarkModeStatus()
        {
            var registryValue = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1);
            GlobalSettings.IsDarkModeEnabled = registryValue != null && registryValue.Equals(0);
        }

        public static bool IsValidFilePath(string path)
        {
            return File.Exists(path) || Directory.Exists(path);
        }
    }
}
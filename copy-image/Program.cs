namespace copy_image
{
    internal static class Program
    {
        [STAThread] // 設定單執行緒單元(STA)模式，因為剪貼簿類需要它
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(args));
        }
    }
}
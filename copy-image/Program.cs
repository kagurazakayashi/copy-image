namespace copy_image
{
    internal static class Program
    {
        [STAThread] // �O���Έ��оw��Ԫ(STA)ģʽ�������N�����Ҫ��
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(args));
        }
    }
}
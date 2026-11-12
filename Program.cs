using System.Text;

namespace My_串口调试助手
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // .NET 10 默认不带 GB2312 等代码页，不注册下面这行，选 GB2312 会直接抛异常
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Application.Run(new Form1());
        }
    }
}
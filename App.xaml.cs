using System.Threading;

namespace WinDbgCourse
{
    using System.Runtime.InteropServices;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        const uint SEM_NOGPFAULTERRORBOX = 0x0002;

        [DllImport("kernel32.dll")]
        internal static extern uint SetErrorMode(uint mode);

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            SetErrorMode(SetErrorMode(0) | SEM_NOGPFAULTERRORBOX);

            if (e.Args.Length == 1 && e.Args[0] == "--crash")
            {
                Thread.Sleep(500);
                MessageBox.Show(Current.MainWindow, (Current.MainWindow.DataContext as MainWindow).Title);
            }

            if (e.Args.Length == 1 && e.Args[0] == "--fast-crash")
            {
                MessageBox.Show(Current.MainWindow, (Current.MainWindow.DataContext as MainWindow).Title);
            }

            MainWindow wnd = new MainWindow();
            wnd.Show();
        }
    }
}
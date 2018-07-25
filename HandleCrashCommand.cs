using System.Windows.Threading;

namespace WinDbgCourse
{
    using System;
    using System.Windows;
    using System.Windows.Input;

    public class HandleCrashCommand : ICommand
    {
        private readonly bool _correct;

        public bool CanExecute(object parameter) => true;

        public event EventHandler CanExecuteChanged;

        public HandleCrashCommand(bool correct)
        {
            _correct = correct;
        }

        public void Execute(object parameter)
        {
            if (_correct)
            {
                AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
                {
                    MessageBox.Show("Something bad happens...");
                };
            }
            else
            {
                Dispatcher.CurrentDispatcher.UnhandledException += (sender, args) =>
                {
                    args.Handled = true;
                    MessageBox.Show("Something bad happens...");
                    Application.Current.Shutdown();
                };
            }

            MessageBox.Show(Application.Current.MainWindow, (Application.Current.MainWindow.DataContext as MainWindow).Title, parameter.ToString());
        }
    }
}
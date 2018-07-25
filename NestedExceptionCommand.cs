namespace WinDbgCourse
{
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;

    public class NestedExceptionCommand : ICommand
    {
        private readonly bool _correct;

        public bool CanExecute(object parameter) => true;

        public event EventHandler CanExecuteChanged;

        public NestedExceptionCommand(bool correct)
        {
            _correct = correct;
        }

        public void Execute(object parameter)
        {
            void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
            {
                args.Handled = true;
                MessageBox.Show("Something bad happens...");
            }

            Dispatcher.CurrentDispatcher.UnhandledException += OnUnhandledException;

            try
            {
                MessageBox.Show(Application.Current.MainWindow, (Application.Current.MainWindow.DataContext as MainWindow).Title, parameter.ToString());
            }
            catch (Exception ex)
            {
                if (_correct)
                    throw new Exception("The first exception is not interesting, so we can use another one", ex);
                throw new Exception("The first exception is not interesting, so we can use another one");
            }

            Dispatcher.CurrentDispatcher.UnhandledException -= OnUnhandledException;
        }
    }
}
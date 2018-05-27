namespace WinDbgCourse
{
    using System;
    using System.Windows;
    using System.Windows.Input;

    public class BasicNullRefCrashCommand : ICommand
    {
        public bool CanExecute(object parameter) => true;

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            MessageBox.Show(Application.Current.MainWindow, (Application.Current.MainWindow.DataContext as MainWindow).Title, parameter.ToString());
        }
    }
}
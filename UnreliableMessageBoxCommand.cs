namespace WinDbgCourse
{
    using System;
    using System.Windows;
    using System.Windows.Input;

    public class UnreliableMessageBoxCommand : ICommand
    {
        public bool CanExecute(object parameter) => true;

        public event EventHandler CanExecuteChanged;

        private static Random _rand;

        public void Execute(object parameter)
        {
            try
            {
                if (_rand == null)
                    _rand = new Random();

                if (_rand.Next(10) < 9)
                    throw new Exception("Make somebody live more interesting!");

                MessageBox.Show(Application.Current.MainWindow, "Omg... it can be shown", "Boring title");
            }
            catch
            {
                // Empty catch block... I love it!
            }
        }
    }
}
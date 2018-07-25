namespace WinDbgCourse
{
    using System.Windows.Input;

    public class MainViewModel
    {
        public ICommand BasicNullRefCrashCommand { get; }

        public ICommand IncorrectlyHandledCrashCommand { get; }

        public ICommand CorrectlyHandledCrashCommand { get; }

        public ICommand UnreliableMessageBoxCommand { get; }

        public ICommand IncorrectNestedException { get; }

        public ICommand CorrectNestedException { get; }

        public MainViewModel()
        {
            BasicNullRefCrashCommand = new BasicNullRefCrashCommand();
            CorrectlyHandledCrashCommand = new HandleCrashCommand(true);
            IncorrectlyHandledCrashCommand = new HandleCrashCommand(false);
            UnreliableMessageBoxCommand = new UnreliableMessageBoxCommand();
            IncorrectNestedException = new NestedExceptionCommand(false);
            CorrectNestedException = new NestedExceptionCommand(true);
        }
    }
}
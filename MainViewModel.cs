namespace WinDbgCourse
{
    using System.Windows.Input;

    public class MainViewModel
    {
        public ICommand BasicNullRefCrashCommand { get; }

        public MainViewModel()
        {
            BasicNullRefCrashCommand = new BasicNullRefCrashCommand();
        }
    }
}
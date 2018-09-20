namespace ElectionSystem.ViewModels
{
    public class LoginViewModel : BaseInpc, IPage
    {
        private MainWindowViewModel _mainWindow;
        public DelegateCommand LoginCommand { get; }

        public LoginViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindow = mainWindowViewModel;
            LoginCommand = new DelegateCommand(LogIn);
        }

        public string Title { get; }

        public void LogIn()
        {
            _mainWindow.GotoWorkspace();
        }
    }
}

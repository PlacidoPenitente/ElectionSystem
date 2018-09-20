namespace ElectionSystem.ViewModels
{
    public class LoginViewModel : BaseInpc, IPage
    {
        private MainWindowViewModel _mainWindow;
        private string _password;

        public DelegateCommand LoginCommand { get; }

        public LoginViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindow = mainWindowViewModel;
            LoginCommand = new DelegateCommand(LogIn);
        }

        public string Title { get; }
        public string Password
        {
            get => _password; set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private string _username;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }


        public void LogIn()
        {
            _mainWindow.GotoWorkspace();
        }
    }
}

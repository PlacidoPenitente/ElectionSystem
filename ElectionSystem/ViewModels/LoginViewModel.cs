using System.Linq;
using ElectionSystem.Models;

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
            var db = new ApplicationDbContext();
            if (db.Voters.Any(x => x.Username.Equals(Username) && x.Password.Equals(Password)))
            {
                _mainWindow.CurrentUser =
                    db.Voters.Single(x => x.Username.Equals(Username) && x.Password.Equals(Password));
                _mainWindow.GotoWorkspace();
            }
        }
    }
}

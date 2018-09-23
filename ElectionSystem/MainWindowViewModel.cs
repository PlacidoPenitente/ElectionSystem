using System.Windows;
using ElectionSystem.Models;
using ElectionSystem.ViewModels;

namespace ElectionSystem
{
    public class MainWindowViewModel : BaseInpc
    {
        private readonly WorkspaceViewModel _workspace;
        private readonly LoginViewModel _loginPage;
        private IPage _currentPage;
        private Voter _currentUser;

        public MainWindowViewModel()
        {
            _workspace = new WorkspaceViewModel(this);
            _loginPage = new LoginViewModel(this);
            CurrentPage = _loginPage;
        }

        public IPage CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public Voter CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }

        public void GotoWorkspace()
        {
            if (CurrentUser == null) return;
            if (CurrentUser.AccountType==AccountType.Administrator)
            {
                _workspace.ForAdmin = Visibility.Visible;
            }
            else
            {
                _workspace.ForAdmin = Visibility.Collapsed;
            }
            CurrentPage = _workspace;
        }

        public void GotoLogin()
        {
            CurrentPage = _loginPage;
        }
    }
}

using ElectionSystem.ViewModels;

namespace ElectionSystem
{
    public class MainWindowViewModel : BaseInpc
    {
        private WorkspaceViewModel _workspace;
        private LoginViewModel _loginPage;
        private IPage _currentPage;

        public MainWindowViewModel()
        {
            Workspace = new WorkspaceViewModel(this);
            LoginPage = new LoginViewModel(this);
            CurrentPage = (IPage)Workspace;
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

        public WorkspaceViewModel Workspace
        {
            get => _workspace;
            set
            {
                _workspace = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel LoginPage
        {
            get => _loginPage;
            set
            {
                _loginPage = value;
                OnPropertyChanged();
            }
        }
    }
}

using ElectionSystem.ViewModels;

namespace ElectionSystem
{
    public class MainWindowViewModel : BaseInpc
    {
        private readonly WorkspaceViewModel _workspace;
        private readonly LoginViewModel _loginPage;
        private IPage _currentPage;

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

        public void GotoWorkspace()
        {
            CurrentPage = _workspace;
        }

        public void GotoLogin()
        {
            CurrentPage = _loginPage;
        }
    }
}

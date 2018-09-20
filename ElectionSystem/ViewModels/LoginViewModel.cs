namespace ElectionSystem.ViewModels
{
    public class LoginViewModel : BaseInpc, IPage
    {
        private MainWindowViewModel _mainWindow;

        public LoginViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this._mainWindow = mainWindowViewModel;
        }

        public string Title { get; }
    }
}

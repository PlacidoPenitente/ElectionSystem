using ElectionSystem.Facades;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class WorkspaceViewModel : BaseInpc, IPage
    {
        private readonly MainWindowViewModel _mainWindow;
        private readonly CreateUpdateVoterViewModel _createUpdateVoter;
        private readonly ReadVotersViewModel _readVoters;

        private readonly CreateUpdateUserViewModel _createUpdateUser;
        private readonly ReadUsersViewModel _readUsers;

        private IWorkspacePageViewModel _currentPage;

        public WorkspaceViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindow = mainWindowViewModel;
            _createUpdateVoter = new CreateUpdateVoterViewModel(new VoterModel(), this);
            _readVoters = new ReadVotersViewModel(this);
            _createUpdateUser = new CreateUpdateUserViewModel(new UserModel(), this);
            _readUsers = new ReadUsersViewModel(this);
            GotoVotersCommand = new DelegateCommand(GotoReadVoters);
            GotoUsersCommand = new DelegateCommand(GotoReadUsers);
        }

        public DelegateCommand GotoVotersCommand { get; }
        public DelegateCommand GotoUsersCommand { get; }

        public IWorkspacePageViewModel CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public string Title { get; }

        public void GotoCreateUpdateVoter(Voter voter = null)
        {
            _createUpdateVoter.Title = "Update Voter";
            if (voter == null) _createUpdateVoter.Title = "Register New Voter";
            _createUpdateVoter.Model.Voter = voter ?? new Voter();
            CurrentPage = _createUpdateVoter;
        }

        public void GotoReadVoters()
        {
            _readVoters.Read();
            CurrentPage = _readVoters;
        }

        public void GotoCreateUpdateUser(User user = null)
        {
            _createUpdateVoter.Title = "Update User";
            if (user == null) _createUpdateVoter.Title = "Register New User";
            _createUpdateUser.Model.User = user ?? new User();
            CurrentPage = _createUpdateUser;
        }

        public void GotoReadUsers()
        {
            _readUsers.Read();
            CurrentPage = _readUsers;
        }

        private DialogViewModel _dialog;

        public DialogViewModel Dialog
        {
            get => _dialog;
            set
            {
                _dialog = value;
                OnPropertyChanged();
            }
        }

        public void ShowYesNoDialog()
        {

        }

        public void ShowWaitDialog()
        {

        }

        public void ShowErrorDialog()
        {

        }

        public void ShowSuccessDialog()
        {

        }

        public void ShowInfoDialog()
        {

        }
    }
}

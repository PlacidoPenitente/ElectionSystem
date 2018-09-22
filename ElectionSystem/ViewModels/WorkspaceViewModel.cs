using System.Linq;
using ElectionSystem.Facades;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class WorkspaceViewModel : BaseInpc, IPage
    {
        private readonly MainWindowViewModel _mainWindow;

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
            _createUpdateParty = new CreateUpdatePartyViewModel(new PartyModel(), this);
            _readParties = new ReadPartiesViewModel(this);
            _createUpdateElection = new CreateUpdateElectionViewModel(new ElectionModel(), this);
            _readElections = new ReadElectionsViewModel(this);
            _createUpdatePosition = new CreateUpdatePositionViewModel(new PositionModel(), this);
            _readPositions = new ReadPositionsViewModel(this);
            GotoVotersCommand = new DelegateCommand(GotoReadVoters);
            GotoUsersCommand = new DelegateCommand(GotoReadUsers);
            GotoPartiesCommand = new DelegateCommand(GotoReadParties);
            GotoElectionsCommand = new DelegateCommand(GotoReadElections);
            GotoPositionsCommand = new DelegateCommand(GotoReadPositions);
        }

        public DelegateCommand GotoUsersCommand { get; }
        public DelegateCommand GotoPartiesCommand { get; }
        public DelegateCommand GotoElectionsCommand { get; }

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

        private readonly CreateUpdateVoterViewModel _createUpdateVoter;
        private readonly ReadVotersViewModel _readVoters;

        public DelegateCommand GotoVotersCommand { get; }

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

        private readonly CreateUpdatePositionViewModel _createUpdatePosition;
        private readonly ReadPositionsViewModel _readPositions;

        public DelegateCommand GotoPositionsCommand { get; }

        public void GotoCreateUpdatePosition(Position position = null)
        {
            _createUpdatePosition.UpdateElections();
            _createUpdatePosition.Title = "Update Position";
            if (position == null) _createUpdatePosition.Title = "Create New Position";
            if (position == null) _createUpdatePosition.Model.Position = new Position();
            else
            {
                _createUpdatePosition.Model.Position = position;
                _createUpdatePosition.Model.Election =
                _createUpdatePosition.Elections.Single(election => election.Id == position.Election.Id);
            }
            CurrentPage = _createUpdatePosition;
        }

        public void GotoReadPositions()
        {
            _readPositions.Read();
            CurrentPage = _readPositions;
        }

        private readonly CreateUpdateElectionViewModel _createUpdateElection;
        private readonly ReadElectionsViewModel _readElections;

        public void GotoCreateUpdateElection(Election election = null)
        {
            _createUpdateElection.Title = "Update Election";
            if (election == null) _createUpdateElection.Title = "Register New Election";
            _createUpdateElection.Model.Election = election ?? new Election();
            CurrentPage = _createUpdateElection;
        }

        public void GotoReadElections()
        {
            _readElections.Read();
            CurrentPage = _readElections;
        }

        private readonly CreateUpdatePartyViewModel _createUpdateParty;
        private readonly ReadPartiesViewModel _readParties;

        public void GotoCreateUpdateParty(Party party = null)
        {
            _createUpdateParty.Title = "Update Party";
            if (party == null) _createUpdateParty.Title = "Create New Party";
            _createUpdateParty.Model.Party = party ?? new Party();
            CurrentPage = _createUpdateParty;
        }

        public void GotoReadParties()
        {
            _readParties.Read();
            CurrentPage = _readParties;
        }

        public void GotoCreateUpdateUser(User user = null)
        {
            _createUpdateVoter.Title = "Update User";
            if (user == null) _createUpdateVoter.Title = "Create New User";
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

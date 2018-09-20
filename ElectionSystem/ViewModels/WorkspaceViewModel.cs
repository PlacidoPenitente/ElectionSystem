using ElectionSystem.Facades;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class WorkspaceViewModel : BaseInpc, IPage
    {
        private readonly MainWindowViewModel _mainWindow;
        private readonly CreateUpdateVoterViewModel _createUpdateVoter;
        private readonly ReadVotersViewModel _readVoters;

        private IWorkspacePageViewModel _currentPage;

        public WorkspaceViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindow = mainWindowViewModel;
            _createUpdateVoter = new CreateUpdateVoterViewModel(new VoterModel(), this);
            _readVoters = new ReadVotersViewModel(this);
            CurrentPage = _readVoters;
        }

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
            if (voter == null) _createUpdateVoter.Title = "Register new Voter";
            _createUpdateVoter.Model.Voter = voter ?? new Voter();
            CurrentPage = _createUpdateVoter;
        }

        public void GotoReadVoters()
        {
            _readVoters.Read();
            CurrentPage = _readVoters;
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

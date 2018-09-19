using ElectionSystem.Facades;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class WorkspaceViewModel : BaseInpc
    {
        private readonly CreateUpdateVoterViewModel _createUpdateVoter;
        private readonly ReadVotersViewModel _readVoters;
        
        private Voter _voter;

        private IWorkspacePageViewModel _currentPage;

        public WorkspaceViewModel()
        {
            _createUpdateVoter = new CreateUpdateVoterViewModel(new VoterModel(_voter), this);
            _readVoters = new ReadVotersViewModel();
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

        public void GotoCreateUpdateVoter(Voter voter = null)
        {
            _voter = null;
            _voter = voter ?? new Voter();
            CurrentPage = _createUpdateVoter;
        }

        public void GotoReadVoters()
        {
            CurrentPage = _readVoters;
        }
    }
}

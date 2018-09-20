using ElectionSystem.Facades;
using System.Data.Entity;
using System.Linq;

namespace ElectionSystem.ViewModels
{
    public class CreateUpdateVoterViewModel : BaseWorkspacePageViewModel, ICreateUpdateViewModel<VoterModel>, IWorkspacePageViewModel, IPage
    {
        private string _title;

        public CreateUpdateVoterViewModel(VoterModel voterModel, WorkspaceViewModel workspaceViewModell)
        {
            Model = voterModel;
            Workspace = workspaceViewModell;
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        public WorkspaceViewModel Workspace { get; }
        public VoterModel Model { get; }
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand CancelCommand { get; }

        public void Cancel()
        {
            Workspace.GotoReadVoters();
        }

        public void Save()
        {
            if (DbContext.Voters.AsQueryable().Any(voter => voter.Id == Model.Voter.Id))
                DbContext.Entry(Model.Voter).State = EntityState.Modified;
            else
                DbContext.Voters.Add(Model.Voter);
            DbContext.SaveChanges();
        }

    }
}

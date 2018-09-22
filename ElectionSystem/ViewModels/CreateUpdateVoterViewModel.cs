using ElectionSystem.Facades;
using System.Data.Entity;
using System.Linq;
using System.Windows;

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
            Workspace.Dialog = new DialogViewModel
            {
                Title = "Save Voter",
                Message = "Are you sure yo want to save this voter?",
                YesVisibility = Visibility.Visible,
                YesCommand = new DelegateCommand(ContinueSave),
                NoVisibility = Visibility.Visible,
                NoCommand = new DelegateCommand(HideDialog),
                OkVisibility = Visibility.Collapsed
            };
        }

        private void HideDialog()
        {
            Workspace.Dialog = null;
        }

        private void ContinueSave()
        {
            if (DbContext.Voters.AsQueryable().Any(voter => voter.Id == Model.Voter.Id))
                DbContext.Entry(Model.Voter).State = EntityState.Modified;
            else
                DbContext.Voters.Add(Model.Voter);
            DbContext.SaveChanges();
            HideDialog();
            Workspace.GotoReadVoters();
        }
    }
}

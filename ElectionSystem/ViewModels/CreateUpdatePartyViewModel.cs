using ElectionSystem.Facades;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace ElectionSystem.ViewModels
{
    public class CreateUpdatePartyViewModel : BaseWorkspacePageViewModel, ICreateUpdateViewModel<PartyModel>, IWorkspacePageViewModel, IPage
    {
        private string _title;

        public CreateUpdatePartyViewModel(PartyModel partyModel, WorkspaceViewModel workspaceViewModel)
        {
            Model = partyModel;
            Workspace = workspaceViewModel;
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
        public PartyModel Model { get; }
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand CancelCommand { get; }

        public void Cancel()
        {
            Workspace.GotoReadParties();
        }

        public void Save()
        {
            Workspace.Dialog = new DialogViewModel
            {
                Title = "Save Party",
                Message = "Are you sure yo want to save this party?",
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
            if (DbContext.Parties.AsQueryable().Any(party => party.Id == Model.Party.Id))
                DbContext.Entry(Model.Party).State = EntityState.Modified;
            else
                DbContext.Parties.Add(Model.Party);
            DbContext.SaveChanges();
            HideDialog();
            Workspace.GotoReadParties();
        }
    }
}

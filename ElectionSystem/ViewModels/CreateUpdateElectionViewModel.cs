using ElectionSystem.Facades;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace ElectionSystem.ViewModels
{
    public class CreateUpdateElectionViewModel : BaseWorkspacePageViewModel, ICreateUpdateViewModel<ElectionModel>, IWorkspacePageViewModel, IPage
    {
        private string _title;

        public CreateUpdateElectionViewModel(ElectionModel electionModel, WorkspaceViewModel workspaceViewModel)
        {
            Model = electionModel;
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
        public ElectionModel Model { get; }
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand CancelCommand { get; }

        public void Cancel()
        {
            Workspace.GotoReadElections();
        }

        public void Save()
        {
            Workspace.Dialog = new DialogViewModel
            {
                Title = "Save Election",
                Message = "Are you sure yo want to save this election?",
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
            if (DbContext.Elections.AsQueryable().Any(election => election.Id == Model.Election.Id))
                DbContext.Entry(Model.Election).State = EntityState.Modified;
            else
                DbContext.Elections.Add(Model.Election);
            DbContext.SaveChanges();
            HideDialog();
            Workspace.GotoReadElections();
        }
    }
}

using ElectionSystem.Facades;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace ElectionSystem.ViewModels
{
    public class CreateUpdateUserViewModel : BaseWorkspacePageViewModel, ICreateUpdateViewModel<UserModel>, IWorkspacePageViewModel, IPage
    {
        private string _title;

        public CreateUpdateUserViewModel(UserModel userModel, WorkspaceViewModel workspaceViewModel)
        {
            Model = userModel;
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
        public UserModel Model { get; }
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand CancelCommand { get; }

        public void Cancel()
        {
            Workspace.GotoReadUsers();
        }

        public void Save()
        {
            Workspace.Dialog = new DialogViewModel
            {
                Title = "Save User",
                Message = "Are you sure yo want to save this user?",
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
            if (DbContext.User.AsQueryable().Any(user => user.Id == Model.User.Id))
                DbContext.Entry(Model.User).State = EntityState.Modified;
            else
                DbContext.User.Add(Model.User);
            DbContext.SaveChanges();
            HideDialog();
            Workspace.GotoReadUsers();
        }
    }
}

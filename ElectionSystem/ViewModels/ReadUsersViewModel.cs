using System.Collections.ObjectModel;
using System.Windows;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class ReadUsersViewModel : BaseWorkspacePageViewModel, IReadViewModel<User>, IWorkspacePageViewModel, IPage
    {
        private ObservableCollection<User> _collection = new ObservableCollection<User>();
        private User _selected;
        private string _searchTerm = "";

        public ReadUsersViewModel(WorkspaceViewModel workspaceViewModel)
        {
            Title = "Users";
            Workspace = workspaceViewModel;
            CreateCommand = new DelegateCommand(Create);
            ReadCommand = new DelegateCommand(Read);
            UpdateCommand = new DelegateCommand(Update);
            DeleteCommand = new DelegateCommand(Delete);
            SearchCommand = new DelegateCommand(Search);
        }

        public string Title { get; }

        public WorkspaceViewModel Workspace { get; }

        public DelegateCommand CreateCommand { get; }

        public DelegateCommand ReadCommand { get; }

        public DelegateCommand UpdateCommand { get; }

        public DelegateCommand DeleteCommand { get; }

        public DelegateCommand SearchCommand { get; }

        public ObservableCollection<User> Collection
        {
            get => _collection;
            set
            {
                _collection = value;
                OnPropertyChanged();
            }
        }

        public User Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                OnPropertyChanged();
            }
        }

        public void Create()
        {
            Workspace.GotoCreateUpdateUser();
        }
        public void Read()
        {
            Collection = new ObservableCollection<User>(DbContext.User);
        }

        public void Update()
        {
            Workspace.GotoCreateUpdateUser(Selected);
        }

        public void Delete()
        {
            Workspace.Dialog = new DialogViewModel
            {
                Title = "Delete User",
                Message = "Are you sure yo want to delete this user?",
                YesVisibility = Visibility.Visible,
                YesCommand = new DelegateCommand(ContinueDelete),
                NoVisibility = Visibility.Visible,
                NoCommand = new DelegateCommand(HideDialog),
                OkVisibility = Visibility.Collapsed
            };
        }

        private void ContinueDelete()
        {
            DbContext.User.Remove(Selected);
            DbContext.SaveChanges();
            Read();
            HideDialog();
        }

        private void HideDialog()
        {
            Workspace.Dialog = null;
        }

        public void Search()
        {
            var tempList = new ObservableCollection<User>();
            foreach (var voter in DbContext.User)
            {
                if (voter.Username.Replace(" ", "").ToLower().Contains(SearchTerm.Replace(" ", "").ToLower()))
                    tempList.Add(voter);
            }
            Collection = tempList;
        }
    }
}
using System.Collections.ObjectModel;
using System.Windows;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class ReadPartiesViewModel : BaseWorkspacePageViewModel, IReadViewModel<Party>, IWorkspacePageViewModel, IPage
    {
        private ObservableCollection<Party> _collection = new ObservableCollection<Party>();
        private Party _selected;
        private string _searchTerm = "";

        public ReadPartiesViewModel(WorkspaceViewModel workspaceViewModel)
        {
            Title = "Registered Parties";
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

        public ObservableCollection<Party> Collection
        {
            get => _collection;
            set
            {
                _collection = value;
                OnPropertyChanged();
            }
        }

        public Party Selected
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
            Workspace.GotoCreateUpdateParty();
        }
        public void Read()
        {
            Collection = new ObservableCollection<Party>(DbContext.Parties);
        }

        public void Update()
        {
            Workspace.GotoCreateUpdateParty(Selected);
        }

        public void Delete()
        {
            Workspace.Dialog = new DialogViewModel
            {
                Title = "Delete Party",
                Message = "Are you sure yo want to delete this party?",
                YesVisibility = Visibility.Visible,
                YesCommand = new DelegateCommand(ContinueDelete),
                NoVisibility = Visibility.Visible,
                NoCommand = new DelegateCommand(HideDialog),
                OkVisibility = Visibility.Collapsed
            };
        }

        private void ContinueDelete()
        {
            DbContext.Parties.Remove(Selected);
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
            var tempList = new ObservableCollection<Party>();
            foreach (var party in DbContext.Parties)
            {
                if (party.Name.Replace(" ", "").ToLower().Contains(SearchTerm.Replace(" ", "").ToLower()))
                    tempList.Add(party);
            }
            Collection = tempList;
        }
    }
}
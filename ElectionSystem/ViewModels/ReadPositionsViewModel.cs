using System.Collections.ObjectModel;
using System.Windows;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class ReadPositionsViewModel : BaseWorkspacePageViewModel, IReadViewModel<Position>, IWorkspacePageViewModel, IPage
    {
        private ObservableCollection<Position> _collection = new ObservableCollection<Position>();
        private Position _selected;
        private string _searchTerm = "";

        public ReadPositionsViewModel(WorkspaceViewModel workspaceViewModel)
        {
            Title = "Positions";
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

        public ObservableCollection<Position> Collection
        {
            get => _collection;
            set
            {
                _collection = value;
                OnPropertyChanged();
            }
        }

        public Position Selected
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
            Workspace.GotoCreateUpdatePosition();
        }
        public void Read()
        {
            Collection = new ObservableCollection<Position>(DbContext.Positions.Include("Election"));
        }

        public void Update()
        {
            Workspace.GotoCreateUpdatePosition(Selected);
        }

        public void Delete()
        {
            Workspace.Dialog = new DialogViewModel
            {
                Title = "Delete Position",
                Message = "Are you sure yo want to delete this position?",
                YesVisibility = Visibility.Visible,
                YesCommand = new DelegateCommand(ContinueDelete),
                NoVisibility = Visibility.Visible,
                NoCommand = new DelegateCommand(HideDialog),
                OkVisibility = Visibility.Collapsed
            };
        }

        private void ContinueDelete()
        {
            DbContext.Positions.Remove(Selected);
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
            var tempList = new ObservableCollection<Position>();
            foreach (var position in DbContext.Positions)
            {
                if (position.Name.Replace(" ", "").ToLower().Contains(SearchTerm.Replace(" ", "").ToLower()))
                    tempList.Add(position);
            }
            Collection = tempList;
        }
    }
}
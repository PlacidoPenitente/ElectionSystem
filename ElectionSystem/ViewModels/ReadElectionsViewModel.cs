using System.Collections.ObjectModel;
using System.Windows;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class ReadElectionsViewModel : BaseWorkspacePageViewModel, IReadViewModel<Election>, IWorkspacePageViewModel, IPage
    {
        private ObservableCollection<Election> _collection = new ObservableCollection<Election>();
        private Election _selected;
        private string _searchTerm = "";

        public ReadElectionsViewModel(WorkspaceViewModel workspaceViewModel)
        {
            Title = "Registered Elections";
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

        public ObservableCollection<Election> Collection
        {
            get => _collection;
            set
            {
                _collection = value;
                OnPropertyChanged();
            }
        }

        public Election Selected
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
            Workspace.GotoCreateUpdateElection();
        }
        public void Read()
        {
            Collection = new ObservableCollection<Election>(DbContext.Elections);
        }

        public void Update()
        {
            Workspace.GotoCreateUpdateElection(Selected);
        }

        public void Delete()
        {
            Workspace.Dialog = new DialogViewModel
            {
                Title = "Delete Election",
                Message = "Are you sure yo want to delete this election?",
                YesVisibility = Visibility.Visible,
                YesCommand = new DelegateCommand(ContinueDelete),
                NoVisibility = Visibility.Visible,
                NoCommand = new DelegateCommand(HideDialog),
                OkVisibility = Visibility.Collapsed
            };
        }

        private void ContinueDelete()
        {
            DbContext.Elections.Remove(Selected);
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
            var tempList = new ObservableCollection<Election>();
            foreach (var election in DbContext.Elections)
            {
                if (election.Name.Replace(" ", "").ToLower().Contains(SearchTerm.Replace(" ", "").ToLower()))
                    tempList.Add(election);
            }
            Collection = tempList;
        }
    }
}
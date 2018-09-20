using System.Collections.ObjectModel;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class ReadVotersViewModel : BaseWorkspacePageViewModel, IReadViewModel<Voter>, IWorkspacePageViewModel
    {
        private ObservableCollection<Voter> _collection;
        private Voter _selected;
        private string _searchTerm;

        public ReadVotersViewModel()
        {
            Title = "Registered Voters";
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

        public ObservableCollection<Voter> Collection
        {
            get => _collection;
            set
            {
                _collection = value;
                OnPropertyChanged();
            }
        }

        public Voter Selected
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
            Workspace.GotoCreateUpdateVoter();
        }
        public void Read()
        {
            Collection = new ObservableCollection<Voter>(DbContext.Voters);
        }

        public void Update()
        {
            Workspace.GotoCreateUpdateVoter(Selected);
        }

        public void Delete()
        {
            DbContext.Voters.Remove(Selected);
            DbContext.SaveChanges();
        }

        public void Search()
        {
            var tempList = new ObservableCollection<Voter>();
            foreach (var voter in Collection)
            {
                var firstNameFirst = string.Concat(voter.FirstName, voter.MiddleName, voter.LastName);
                var lastNameFirst = string.Concat(voter.LastName, voter.FirstName, voter.MiddleName);

                if (firstNameFirst.Replace(" ", "").ToLower().Contains(SearchTerm.Replace(" ", "").ToLower())||
                    lastNameFirst.Replace(" ", "").ToLower().Contains(SearchTerm.Replace(" ", "").ToLower()))
                    tempList.Add(voter);
                
            }
            Collection = tempList;
        }
    }
}
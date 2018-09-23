using System.Collections.ObjectModel;
using System.Linq;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class VoteViewModel : BaseWorkspacePageViewModel, IWorkspacePageViewModel
    {
        public WorkspaceViewModel Workspace { get; }

        private Candidacy _selected;

        public Candidacy Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Candidacy> _collection;

        public ObservableCollection<Candidacy> Collection
        {
            get => _collection;
            set
            {
                _collection = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Candidacy> _ballot;

        public ObservableCollection<Candidacy> Ballot
        {
            get => _ballot;
            set
            {
                _ballot = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand VoteCommand { get; set; }

        private string _searchTerm = "";

        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                OnPropertyChanged();
            }
        }

        public VoteViewModel()
        {
            Collection = new ObservableCollection<Candidacy>();
            SearchCommand = new DelegateCommand(Search);
            VoteCommand = new DelegateCommand(Vote);
            Ballot = new ObservableCollection<Candidacy>();
            RemoveCommand = new DelegateCommand(RemoveCandidate);
        }

        private Candidacy _selectedCandidate;

        public Candidacy SelectedCandidate
        {
            get => _selectedCandidate;
            set
            {
                _selectedCandidate = value;
                OnPropertyChanged();
            }
        }

        public void RemoveCandidate()
        {
            Ballot.Remove(SelectedCandidate);
        }

        public DelegateCommand RemoveCommand { get; set; }

        public void Vote()
        {
            if (Ballot.All(x => x.Id != Selected.Id))
            {
                int found = Ballot.Count(x => x.Position.Id == Selected.Position.Id && x.Position.Election.Id == Selected.Position.Election.Id);
                if (found < Selected.Position.Slots)
                {
                    Ballot.Add(Selected);
                }
            }
        }

        public void Search()
        {
            Collection = new ObservableCollection<Candidacy>(DbContext.Candidacies.Include("Position").Include("Candidate").Include("Party"));
            foreach (var candidacy in Collection)
            {
                candidacy.Position =
                    DbContext.Positions.Include("Election").Single(position => position.Id == candidacy.Position.Id);
            }

            var tempList = new ObservableCollection<Candidacy>();
            foreach (var candidacy in DbContext.Candidacies)
            {
                var firstNameFirst = string.Concat(candidacy.Candidate.FirstName, candidacy.Candidate.MiddleName, candidacy.Candidate.LastName);
                var lastNameFirst = string.Concat(candidacy.Candidate.LastName, candidacy.Candidate.FirstName, candidacy.Candidate.MiddleName);

                if (firstNameFirst.Replace(" ", "").ToLower().Contains(SearchTerm.Replace(" ", "").ToLower()) ||
                    lastNameFirst.Replace(" ", "").ToLower().Contains(SearchTerm.Replace(" ", "").ToLower()))
                    tempList.Add(candidacy);
            }
            Collection = tempList;
        }
    }
}

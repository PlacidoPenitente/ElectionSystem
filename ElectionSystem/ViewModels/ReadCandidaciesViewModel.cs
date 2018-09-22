using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class ReadCandidaciesViewModel : BaseWorkspacePageViewModel, IReadViewModel<Candidacy>, IWorkspacePageViewModel, IPage
    {
        private ObservableCollection<Candidacy> _collection = new ObservableCollection<Candidacy>();
        private Candidacy _selected;
        private string _searchTerm = "";

        public ReadCandidaciesViewModel(WorkspaceViewModel workspaceViewModel)
        {
            Title = "Candidacies";
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

        public ObservableCollection<Candidacy> Collection
        {
            get => _collection;
            set
            {
                _collection = value;
                OnPropertyChanged();
            }
        }

        public Candidacy Selected
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
            Workspace.GotoCreateUpdateCandidacy();
        }
        public void Read()
        {
            Collection = new ObservableCollection<Candidacy>(DbContext.Candidacies.Include("Position").Include("Candidate").Include("Party"));
            foreach (var candidacy in Collection)
            {
                candidacy.Position =
                    DbContext.Positions.Include("Election").Single(position => position.Id == candidacy.Position.Id);
            }
        }

        public void Update()
        {
            Workspace.GotoCreateUpdateCandidacy(Selected);
        }

        public void Delete()
        {
            Workspace.Dialog = new DialogViewModel
            {
                Title = "Delete Candidacy",
                Message = "Are you sure yo want to delete this candidacy?",
                YesVisibility = Visibility.Visible,
                YesCommand = new DelegateCommand(ContinueDelete),
                NoVisibility = Visibility.Visible,
                NoCommand = new DelegateCommand(HideDialog),
                OkVisibility = Visibility.Collapsed
            };
        }

        private void ContinueDelete()
        {
            DbContext.Candidacies.Remove(Selected);
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
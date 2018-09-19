using System.Collections.ObjectModel;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class ReadVotersViewModel : BaseWorkspacePageViewModel, IReadViewModel<Voter>, IWorkspacePageViewModel
    {
        private ObservableCollection<Voter> _collection;
        private Voter _selected;

        public ReadVotersViewModel()
        {
            CreateCommand = new DelegateCommand(Create);
            ReadCommand = new DelegateCommand(Read);
            UpdateCommand = new DelegateCommand(Update);
            DeleteCommand = new DelegateCommand(Delete);
        }

        public WorkspaceViewModel Workspace { get; }
        
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

        public DelegateCommand CreateCommand { get; }

        public DelegateCommand ReadCommand { get; }

        public DelegateCommand UpdateCommand { get; }

        public DelegateCommand DeleteCommand { get; }

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
    }
}
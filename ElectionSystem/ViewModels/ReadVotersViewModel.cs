using System.Collections.ObjectModel;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class ReadVotersViewModel : BaseWorkspacePageViewModel, IReadViewModel<Voter>, IWorkspacePageViewModel
    {
        public WorkspaceViewModel Workspace { get; }

        private ObservableCollection<Voter> _collection;

        public ObservableCollection<Voter> Collection
        {
            get => _collection;
            set
            {
                _collection = value;
                OnPropertyChanged();
            }
        }

        private Voter _selected;

        public Voter Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        public void Load()
        {
            Collection = new ObservableCollection<Voter>(DbContext.Voters);
        }

        public void AddNew()
        {
            Workspace.GotoCreateUpdateVoter();
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
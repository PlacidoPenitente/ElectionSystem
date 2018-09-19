using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class ElectionModel : BaseInpc
    {
        private readonly Election _election;

        public ElectionModel(Election election)
        {
            _election = election;
        }

        public int Id { get => _election.Id; }

        public string Name
        {
            get => _election.Name;
            set
            {
                _election.Name = value;
                OnPropertyChanged();
            }
        }

        public bool IsOpen
        {
            get => _election.IsOpen;
            set
            {
                _election.IsOpen = value;
                OnPropertyChanged();
            }
        }
    }
}

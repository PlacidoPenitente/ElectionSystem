using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class ElectionModel : BaseInpc
    {
        public ElectionModel(Election election)
        {
            Election = election;
        }

        public Election Election { get; }

        public string Name
        {
            get => Election.Name;
            set
            {
                Election.Name = value;
                OnPropertyChanged();
            }
        }

        public bool IsOpen
        {
            get => Election.IsOpen;
            set
            {
                Election.IsOpen = value;
                OnPropertyChanged();
            }
        }
    }
}

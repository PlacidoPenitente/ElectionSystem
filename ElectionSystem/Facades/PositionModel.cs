using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class PositionModel : BaseInpc
    {
        public Position Position { get; set; }

        public string Name
        {
            get => Position.Name;
            set
            {
                Position.Name = value;
                OnPropertyChanged();
            }
        }

        public int? Slots
        {
            get => Position.Slots;
            set
            {
                Position.Slots = value;
                OnPropertyChanged();
            }
        }

        public Election Election
        {
            get => Position.Election;
            set
            {
                Position.Election= value;
                OnPropertyChanged();
            }
        }
    }
}

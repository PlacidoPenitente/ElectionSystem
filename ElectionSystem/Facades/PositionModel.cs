using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class PositionModel : BaseInpc
    {
        public PositionModel(Position position)
        {
            Position = position;
        }

        public Position Position { get; }

        public string Name
        {
            get => Position.Name;
            set
            {
                Position.Name = value;
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

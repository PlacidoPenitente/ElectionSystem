using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class PositionModel : BaseInpc
    {
        private readonly Position _position;

        public PositionModel(Position position)
        {
            _position = position;
        }

        public int Id { get => _position.Id; }

        public string Position
        {
            get => _position.Name;
            set
            {
                _position.Name = value;
                OnPropertyChanged();
            }
        }

        public Election Election
        {
            get => _position.Election;
            set
            {
                _position.Election= value;
                OnPropertyChanged();
            }
        }
    }
}

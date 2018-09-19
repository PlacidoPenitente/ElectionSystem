using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public class PartyModel : BaseInpc
    {
        private readonly Party _party;

        public PartyModel(Party party)
        {
            _party = party;
        }

        public int Id { get => _party.Id; }

        public string Name
        {
            get => _party.Name;
            set
            {
                _party.Name = value;
                OnPropertyChanged();
            }
        }

        public string Logo
        {
            get => _party.Logo;
            set
            {
                _party.Logo = value;
                OnPropertyChanged();
            }
        }
    }
}

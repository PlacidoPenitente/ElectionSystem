using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class PartyModel : BaseInpc
    {
        public PartyModel(Party party)
        {
            Party = party;
        }

        public Party Party { get; }

        public string Name
        {
            get => Party.Name;
            set
            {
                Party.Name = value;
                OnPropertyChanged();
            }
        }

        public string Logo
        {
            get => Party.Logo;
            set
            {
                Party.Logo = value;
                OnPropertyChanged();
            }
        }
    }
}

using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class CandidacyModel : BaseInpc
    {
        private readonly Candidacy _candidacy;

        public CandidacyModel(Candidacy candidacy)
        {
            _candidacy = candidacy;
        }

        public int Id { get => _candidacy.Id; }

        public Voter Candidate
        {
            get => _candidacy.Candidate;
            set
            {
                _candidacy.Candidate = value;
                OnPropertyChanged();
            }
        }

        public Party Party
        {
            get => _candidacy.Party;
            set
            {
                _candidacy.Party = value;
                OnPropertyChanged();
            }
        }

        public Position Position
        {
            get => _candidacy.Position;
            set
            {
                _candidacy.Position = value;
                OnPropertyChanged();
            }
        }
    }
}

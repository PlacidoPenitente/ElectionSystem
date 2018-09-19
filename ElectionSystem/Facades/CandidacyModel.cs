using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class CandidacyModel : BaseInpc
    {
        public CandidacyModel(Candidacy candidacy)
        {
            Candidacy = candidacy;
        }

        public Candidacy Candidacy { get; }

        public Voter Candidate
        {
            get => Candidacy.Candidate;
            set
            {
                Candidacy.Candidate = value;
                OnPropertyChanged();
            }
        }

        public Party Party
        {
            get => Candidacy.Party;
            set
            {
                Candidacy.Party = value;
                OnPropertyChanged();
            }
        }

        public Position Position
        {
            get => Candidacy.Position;
            set
            {
                Candidacy.Position = value;
                OnPropertyChanged();
            }
        }
    }
}

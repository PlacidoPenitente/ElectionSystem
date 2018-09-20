using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class CandidacyModel : BaseInpc
    {
        public Candidacy Candidacy { get; set; }

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

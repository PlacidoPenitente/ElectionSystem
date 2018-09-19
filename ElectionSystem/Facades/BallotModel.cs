using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class BallotModel : BaseInpc
    {
        public BallotModel(Ballot ballot)
        {
            Ballot = ballot;
        }

        public Ballot Ballot { get; }

        public Voter Voter
        {
            get => Ballot.Voter;
            set
            {
                Ballot.Voter = value;
                OnPropertyChanged();
            }
        }
    }
}

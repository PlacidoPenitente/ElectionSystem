using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class BallotModel : BaseInpc
    {
        public Ballot Ballot { get; set; }

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

using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class BallotModel : BaseInpc
    {
        private readonly Ballot _ballot;

        public BallotModel(Ballot ballot)
        {
            _ballot = ballot;
        }

        public int Id { get => _ballot.Id; }

        public Voter Voter
        {
            get => _ballot.Voter;
            set
            {
                _ballot.Voter = value;
                OnPropertyChanged();
            }
        }
    }
}

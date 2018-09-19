using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public class VoteModel : BaseInpc
    {
        private readonly Vote _vote;

        public VoteModel(Vote vote)
        {
            _vote = vote;
        }

        public int Id { get => _vote.Id; }

        public Candidacy Candidacy
        {
            get => _vote.Candidacy;
            set
            {
                _vote.Candidacy= value;
                OnPropertyChanged();
            }
        }

        public Ballot Ballot
        {
            get => _vote.Ballot;
            set
            {
                _vote.Ballot= value;
                OnPropertyChanged();
            }
        }
    }
}

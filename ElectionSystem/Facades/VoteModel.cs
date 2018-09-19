using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class VoteModel : BaseInpc
    {
        public VoteModel(Vote vote)
        {
            Vote = vote;
        }

        public Vote Vote { get; }

        public Candidacy Candidacy
        {
            get => Vote.Candidacy;
            set
            {
                Vote.Candidacy= value;
                OnPropertyChanged();
            }
        }

        public Ballot Ballot
        {
            get => Vote.Ballot;
            set
            {
                Vote.Ballot= value;
                OnPropertyChanged();
            }
        }
    }
}

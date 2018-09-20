using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class VoteModel : BaseInpc
    {
        public Vote Vote { get; set; }

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

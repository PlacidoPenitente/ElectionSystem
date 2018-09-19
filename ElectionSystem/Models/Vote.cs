namespace ElectionSystem.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public Candidacy Candidacy { get; set; }
        public Ballot Ballot { get; set; }
    }
}

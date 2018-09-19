namespace ElectionSystem.Models
{
    public class Candidacy
    {
        public int Id { get; set; }
        public Voter Candidate { get; set; }
        public Party Party { get; set; }
        public Position Position { get; set; }
    }
}

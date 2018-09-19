namespace ElectionSystem.Models
{
    public sealed class Candidacy : BaseModel
    {
        public int Id { get; set; }
        public Voter Candidate { get; set; }
        public Party Party { get; set; }
        public Position Position { get; set; }
    }
}

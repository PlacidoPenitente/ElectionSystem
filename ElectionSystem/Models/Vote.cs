namespace ElectionSystem.Models
{
    public sealed class Vote : BaseModel
    {
        public int Id { get; set; }
        public Candidacy Candidacy { get; set; }
        public Ballot Ballot { get; set; }
    }
}

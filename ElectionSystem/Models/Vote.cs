namespace ElectionSystem.Models
{
    public sealed class Vote : BaseModel
    {
        public int Id { get; set; } = -1;
        public Candidacy Candidacy { get; set; }
        public Ballot Ballot { get; set; }
    }
}

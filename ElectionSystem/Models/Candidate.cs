namespace ElectionSystem.Models
{
    public class Candidate : Voter
    {
        public Position Type { get; set; }
        public Party Party { get; set; }
    }
}

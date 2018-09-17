namespace ElectionSystem.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumNoOfWinners { get; set; }
        public int MaximumNoOfWinners { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace ElectionSystem.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public Election Election { get; set; }
    }
}
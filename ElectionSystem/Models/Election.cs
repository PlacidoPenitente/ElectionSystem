using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionSystem.Models
{
    public class Election
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public bool IsOpen { get; set; }
    }
}

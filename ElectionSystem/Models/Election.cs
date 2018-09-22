using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionSystem.Models
{
    public sealed class Election : BaseModel
    {
        public int Id { get; set; } = -1;
        [Required]
        [MaxLength(255)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public bool IsOpen { get; set; }
    }
}

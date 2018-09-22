using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionSystem.Models
{
    public sealed class Party : BaseModel
    {
        public int Id { get; set; } = -1;
        [Required]
        [MaxLength(255)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public string Logo { get; set; }
    }
}
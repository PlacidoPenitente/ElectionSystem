using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(64)]
        [MinLength(8)]
        [Index(IsUnique = true)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(64)]
        [MinLength(8)]
        public string Password { get; set; }
        public AccountType AccountType { get; set; }
    }
}

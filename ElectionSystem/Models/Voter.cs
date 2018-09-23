using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionSystem.Models
{
    public sealed class Voter : BaseModel
    {
        public int Id { get; set; } = -1;
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public Gender Gender { get; set; }
        [Required]
        [MaxLength(255)]
        public string Address { get; set; }
        public string Photo { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(64)]
        [MinLength(8)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(64)]
        [MinLength(8)]
        public string Password { get; set; }
        public AccountType AccountType { get; set; }
    }
}

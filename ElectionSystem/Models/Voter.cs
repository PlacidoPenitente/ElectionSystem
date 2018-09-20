using System;
using System.ComponentModel.DataAnnotations;

namespace ElectionSystem.Models
{
    public sealed class Voter : BaseModel
    {
        public int Id { get; set; }
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
    }
}

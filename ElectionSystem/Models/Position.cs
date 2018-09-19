﻿using System.ComponentModel.DataAnnotations;

namespace ElectionSystem.Models
{
    public sealed class Position : BaseModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public Election Election { get; set; }
    }
}
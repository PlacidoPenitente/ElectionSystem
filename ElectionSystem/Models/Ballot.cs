using System;

namespace ElectionSystem.Models
{
    public sealed class Ballot : BaseModel
    {
        public int Id { get; set; }
        public Voter Voter { get; set; }
    }
}

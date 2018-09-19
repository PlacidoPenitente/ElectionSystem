using System;

namespace ElectionSystem.Models
{
    public class Ballot
    {
        public int Id { get; set; }
        public Voter Voter { get; set; }
    }
}

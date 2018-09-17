using System.Data.Entity;

namespace ElectionSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("electiondb")
        {
            
        }

        public static ApplicationDbContext Instance { get; } = new ApplicationDbContext();
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}

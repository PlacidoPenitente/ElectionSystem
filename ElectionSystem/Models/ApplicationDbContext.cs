using System.Data.Entity;

namespace ElectionSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("electiondb")
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Candidacy> Candidacies { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Ballot> Ballots { get; set; }

    }
}

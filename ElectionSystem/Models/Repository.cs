namespace ElectionSystem.Models
{
    public class Repository
    {
        public static Repository Instance { get; }

        static Repository()
        {
            Instance = new Repository();
        }

        private Repository()
        {

        }

        public ApplicationDbContext CreateApplicationDbContext()
        {
            return new ApplicationDbContext();
        }
    }
}

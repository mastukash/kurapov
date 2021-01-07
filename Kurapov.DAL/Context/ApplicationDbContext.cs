using System.Data.Entity;

namespace Kurapov.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        static ApplicationDbContext()
        {
        }
        public ApplicationDbContext(): base("DBConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<TypeChat> TypesChats { get; set; }
    }
}

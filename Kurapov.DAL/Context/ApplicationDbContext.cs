using Kurapov.DAL.Entities;
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

            //One to One (Body->Header)
            //modelBuilder.Entity<Header>()
            //    .HasRequired(c => c.Body)
            //    .WithRequiredPrincipal(c => c.Header)
            //    .WillCascadeOnDelete(false);

            //One-to–Zero-or-One (Document -> Header)
            modelBuilder.Entity<Header>()
                .HasRequired(c => c.Document)
                .WithOptional(c => c.Header)
                .WillCascadeOnDelete(false);

            //One-to–Zero-or-One (Document -> Body)
            modelBuilder.Entity<Body>()
                .HasRequired(c => c.Document)
                .WithOptional(c => c.Body)
                .WillCascadeOnDelete(false);
        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<Body> Bodies { get; set; }
        public DbSet<Line> Lines { get; set; }
    }
}

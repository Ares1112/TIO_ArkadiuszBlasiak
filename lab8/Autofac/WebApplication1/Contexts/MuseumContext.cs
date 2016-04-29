using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Contexts
{
    public class MuseumContext : DbContext
    {
        public MuseumContext() : base("MuseumContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<Painting> Paintings { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

    }
}
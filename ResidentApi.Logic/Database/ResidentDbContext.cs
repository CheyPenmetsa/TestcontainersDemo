using Microsoft.EntityFrameworkCore;
using ResidentApi.Logic.Domain;

namespace ResidentApi.Logic.Database
{
    public class ResidentDbContext : DbContext
    {
        public ResidentDbContext(DbContextOptions<ResidentDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Resident> Residents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resident>()
                .Property(x => x.FirstName).IsRequired(true);

            modelBuilder.Entity<Resident>()
               .Property(x => x.LastName).IsRequired(true);

            modelBuilder.Entity<Resident>()
               .Property(x => x.Id).IsRequired(true);

            modelBuilder.Entity<Resident>()
               .Property(x => x.Age).IsRequired(false);
        }
    }
}

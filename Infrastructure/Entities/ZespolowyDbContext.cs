using Infrastructure.Entities.Main;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities
{
    public class ZespolowyDbContext : DbContext
    {
        public ZespolowyDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Employers> Employers { get; set; }
        public virtual DbSet<JobOffers> JobOffers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:sggw-zespolowy-sql-srv.database.windows.net,1433;Initial Catalog=sggw-zespolowy-sql;Persist Security Info=False;User ID=zespolowy;Password=Zespołowy2023;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

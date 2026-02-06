using Microsoft.EntityFrameworkCore;
using NukeLogin.Src.Domain.Entitys;

namespace NukeLogin.Src.Infrastructure
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}

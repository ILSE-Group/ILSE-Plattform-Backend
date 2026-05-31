using BogenElDorado.Persistence.Identity;
using Domain.DomainObjects.Topics;
using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.DomainObjects.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> DomainUsers { get; set; }

        public DbSet<Topic> UserReports { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Loads all configuration classes from the assembly and applies them
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly);
        }
    }
}

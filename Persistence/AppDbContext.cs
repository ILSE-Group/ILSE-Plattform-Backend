using Domain.DomainObjects;
using Domain.DomainObjects.Progresses;
using Domain.DomainObjects.Topics;
using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.DomainObjects.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Identity;

namespace Persistence
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Topic>            Topics             { get; set; }
        public DbSet<Room>             Rooms              { get; set; }
        public DbSet<Exercise>         Exercises          { get; set; }
        public DbSet<Level>            Levels             { get; set; }
        public DbSet<OneTimePassword>  OneTimePasswords   { get; set; }
        public DbSet<ExerciseProgress> ExerciseProgresses { get; set; }
        public DbSet<RoomProgress>     RoomProgresses     { get; set; }
        public DbSet<UserProgress>     UserProgresses     { get; set; }
        public DbSet<User>             Users              { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferField);

            // Loads all IEntityTypeConfiguration<T> classes from this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly);
        }
    }
}
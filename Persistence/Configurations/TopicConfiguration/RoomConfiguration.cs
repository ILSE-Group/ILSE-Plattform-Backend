using Domain.DomainObjects.Topics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging.Abstractions;

namespace Persistence.Configurations.ExerciseConfigurations
{
    internal class RoomConfiguration
    {
        public void Configuration(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.UnlockLevel)
                .IsRequired();

            builder.Property(e => e.CompletionExperiencePoints)
                .IsRequired();

            builder.HasMany(e => e.Exercises)
                .WithOne()
                .HasForeignKey("RoomId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

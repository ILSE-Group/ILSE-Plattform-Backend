using Domain.DomainObjects.Topics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.ExerciseConfigurations
{
    internal class TopicConfiguration
    {
        public void Configuration(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("Topics");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasMany(e => e.Rooms)
                .WithOne()
                .HasForeignKey("TopicId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

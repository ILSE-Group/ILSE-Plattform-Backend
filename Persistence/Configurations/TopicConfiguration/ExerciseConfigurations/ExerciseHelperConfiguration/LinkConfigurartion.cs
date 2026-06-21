using Domain.DomainObjects.Topics.Exercises.ExerciseHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.TopicConfiguration.ExerciseConfigurations
{
    internal class LinkConfiguration : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.ToTable("Links");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.LeftItem)
                   .IsRequired();
            builder.Property(l => l.RightItem)
                   .IsRequired();
        }
    }
}
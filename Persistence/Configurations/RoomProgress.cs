using Domain.DomainObjects.Progresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Persistence.Configurations.ProgressConfigurations
{
    internal class RoomProgressConfiguration : IEntityTypeConfiguration<RoomProgress>
    {
        public void Configure(EntityTypeBuilder<RoomProgress> builder)
        {
            builder.ToTable("RoomProgresses");

            builder.HasKey(rp => rp.Id);

            builder.Property(rp => rp.Id)
                   .ValueGeneratedNever();

            builder.Property(rp => rp.UserId)
                   .IsRequired();

            builder.Property(rp => rp.RoomId)
                   .IsRequired();

            builder.Property(rp => rp.CompletedRooms)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                       v => JsonSerializer.Deserialize<List<Guid>>(v, (JsonSerializerOptions)null)
                   );
        }
    }
}
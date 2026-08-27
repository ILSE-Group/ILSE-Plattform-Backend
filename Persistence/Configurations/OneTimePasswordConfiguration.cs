using Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class OneTimePasswordConfiguration : IEntityTypeConfiguration<OneTimePassword>
    {
        public void Configure(EntityTypeBuilder<OneTimePassword> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.CodeHash)
                .IsRequired()
                .HasMaxLength(64); // SHA-256 Hex = 64 Zeichen

            builder.HasIndex(o => o.CodeHash).IsUnique();

            builder.Property(o => o.ExpiresAt).IsRequired();
        }
    }
}
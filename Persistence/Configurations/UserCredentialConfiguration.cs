using Domain.DomainObjects.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserCredentialConfiguration : IEntityTypeConfiguration<UserCredential>
    {
        public void Configure(EntityTypeBuilder<UserCredential> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.SecretIdHash)
                .IsRequired()
                .HasMaxLength(64);

            builder.HasIndex(c => c.SecretIdHash).IsUnique();
            builder.HasIndex(c => c.UserId).IsUnique(); // ein Credential pro User

            builder.Property(c => c.PasswordHash).IsRequired();
            builder.Property(c => c.PasswordSalt).IsRequired();
        }
    }
}
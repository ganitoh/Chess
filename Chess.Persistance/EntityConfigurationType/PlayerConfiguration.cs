using Chess.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Persistance.EntityConfigurationType
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.LocalMMR).HasDefaultValue(200);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Login).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(50);

            builder.HasAlternateKey(x => x.Login);
            builder.ToTable(t => t.HasCheckConstraint("localMMR", "localMMR > 0"));
            builder.Property(x => x.Login).HasMaxLength(30);
        }
    }
}

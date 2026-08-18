using AdsSqlApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsSqlApi.Infrastructure.Persistence.Configurations
{
    public sealed class PadsConfiguration : IEntityTypeConfiguration<Pads>
    {
        public void Configure(EntityTypeBuilder<Pads> builder)
        {
            builder.ToTable("Pads");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(50).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.CreatedAtUtc).IsRequired();
        }
    }
}

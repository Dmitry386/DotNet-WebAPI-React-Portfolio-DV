using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Core.Models;
using Portfolio.DataAccess.Entities;

namespace Portfolio.DataAccess.Configurators
{
    public class PortfolioConfiguration : IEntityTypeConfiguration<PortfolioEntity>
    {
        public void Configure(EntityTypeBuilder<PortfolioEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(PortfolioModel.MAX_NAME_LENGTH)
                .IsRequired();

            builder.Property(e => e.Surname)
                .HasMaxLength(PortfolioModel.MAX_NAME_LENGTH)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(PortfolioModel.MAX_DESCRIPTION_LENGTH)
                .IsRequired();
        }
    }
}
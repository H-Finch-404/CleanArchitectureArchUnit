using CleanArchitectureArchUnit.Core.Aggregates.ContributorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureArchUnit.Infrastructure.Data.Config;

internal class ContributorConfiguration : IEntityTypeConfiguration<Contributor>
{
  public void Configure(EntityTypeBuilder<Contributor> builder)
  {
    builder.Property(p => p.Name)
        .HasMaxLength(100)
        .IsRequired();
  }
}

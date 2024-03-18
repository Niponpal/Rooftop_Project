using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Top_Rooftop_project.Models;

namespace Top_Rooftop_project.ModelConfigration;

public class HouseOwnerConfigaration : IEntityTypeConfiguration<HouseOwners>
{
	public void Configure(EntityTypeBuilder<HouseOwners> builder)
	{
		builder.ToTable(nameof(HouseOwners));
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Name).HasMaxLength(156).IsRequired();
		builder.Property(x => x.Email).HasMaxLength(156).IsRequired();
		builder.Property(x => x.Password).HasMaxLength(156).IsRequired();
	}
}

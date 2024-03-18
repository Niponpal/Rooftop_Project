using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Top_Rooftop_project.Models;

namespace Top_Rooftop_project.ModelConfigration;

public class FarmerConfigaration : IEntityTypeConfiguration<Farmer>
{
	public void Configure(EntityTypeBuilder<Farmer> builder)
	{
		builder.ToTable(nameof(Farmer));
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Name).HasMaxLength(64).IsRequired();
		builder.Property(x => x.Email).HasMaxLength(64).IsRequired();
		builder.Property(x => x.SquarFeet).HasMaxLength(64).IsRequired();
		builder.Property(x => x.Location).HasMaxLength(64).IsRequired();
		builder.Property(x => x.Image1).HasMaxLength(64).IsRequired();
		builder.Property(x => x.Image2).HasMaxLength(64).IsRequired();
		builder.Property(x => x.Image3).HasMaxLength(64).IsRequired();
		builder.Property(x => x.GoogleMap).HasMaxLength(64).IsRequired();
		builder.Property(x => x.SomeDetails).HasMaxLength(64).IsRequired();
		builder.Property(x => x.MoreDetails).HasMaxLength(64).IsRequired();
		builder.Property(x => x.Price).HasMaxLength(64).IsRequired();		
	}
}

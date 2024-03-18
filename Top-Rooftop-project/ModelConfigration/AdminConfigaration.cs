using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Top_Rooftop_project.Models;

namespace Top_Rooftop_project.ModelConfigration;

public class AdminConfigaration : IEntityTypeConfiguration<Admin>
{
	public void Configure(EntityTypeBuilder<Admin> builder)
	{
		builder.ToTable(nameof(Admin));
		builder.HasKey(a => a.Id);
		builder.Property(a=>a.Email).HasMaxLength(128).IsRequired();
		builder.Property(a=>a.Password).HasMaxLength(128).IsRequired();
	}
}

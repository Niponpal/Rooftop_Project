using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Top_Rooftop_project.Models;

namespace Top_Rooftop_project.ModelConfigration;

public class UserConfigration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable(nameof(User));
		builder.HasKey(x => x.Id);
		builder.Property(x=>x.Email).HasMaxLength(128).IsRequired();
		builder.Property(x=>x.UserName).HasMaxLength(128).IsRequired();
		builder.Property(x=>x.Password).HasMaxLength(128).IsRequired();
	}
}

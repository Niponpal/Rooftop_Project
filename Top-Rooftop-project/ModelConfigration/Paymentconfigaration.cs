using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Top_Rooftop_project.Models;

namespace Top_Rooftop_project.ModelConfigration;

public class Paymentconfigaration : IEntityTypeConfiguration<Payment>
{
	public void Configure(EntityTypeBuilder<Payment> builder)
	{
		builder.ToTable(nameof(Payment));
		builder.HasKey(x => x.Id);
		builder.Property(x=>x.TransId).HasMaxLength(128).IsRequired();
		builder.Property(x=>x.Email).HasMaxLength(128).IsRequired();
		builder.Property(x=>x.IsPaymentConfirm).HasMaxLength(128).IsRequired();
		builder.Property(x=>x.Cartitems).HasMaxLength(128).IsRequired();
		builder.Property(x=>x.OrderTime).HasMaxLength(128).IsRequired();
		
	}
}

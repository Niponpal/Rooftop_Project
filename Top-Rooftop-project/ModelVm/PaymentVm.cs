using AutoMapper;
using Top_Rooftop_project.Models;

namespace Top_Rooftop_project.ModelVm;
[AutoMap(typeof(Payment), ReverseMap = true)]
public class PaymentVm
{
	public int Id { get; set; }
	public string TransId { get; set; }
	public string Email { get; set; }
	public string IsPaymentConfirm { get; set; }
	public string Cartitems { get; set; }
	public string OrderTime { get; set; }
}

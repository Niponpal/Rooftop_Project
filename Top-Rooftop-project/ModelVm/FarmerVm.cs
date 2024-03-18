using AutoMapper;
using Top_Rooftop_project.Models;

namespace Top_Rooftop_project.ModelVm;
[AutoMap(typeof(Farmer),ReverseMap = true)]
public class FarmerVm
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public string SquarFeet { get; set; }
	public string Location { get; set; }
	public string Image1 { get; set; }
	public string Image2 { get; set; }
	public string Image3 { get; set; }
	public string GoogleMap { get; set; }
	public string SomeDetails { get; set; }
	public string MoreDetails { get; set; }
	public string Price { get; set; }
}

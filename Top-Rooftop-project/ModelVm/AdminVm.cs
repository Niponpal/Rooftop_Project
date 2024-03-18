using AutoMapper;
using Top_Rooftop_project.Models;

namespace Top_Rooftop_project.ModelVm;
[AutoMap(typeof(Admin),ReverseMap = true)]
public class AdminVm
{
	public int Id { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
}

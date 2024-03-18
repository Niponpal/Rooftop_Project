using AutoMapper;
using Top_Rooftop_project.Models;

namespace Top_Rooftop_project.ModelVm;
[AutoMap(typeof(User), ReverseMap = true)]
public class UserVm
{
	public int Id { get; set; }
	public string Email { get; set; }
	public string UserName { get; set; }
	public string Password { get; set; }
}

using AutoMapper;
using Top_Rooftop_project.Database;
using Top_Rooftop_project.Models;
using Top_Rooftop_project.ModelVm;
using Top_Rooftop_project.Services;

namespace Top_Rooftop_project.RepositoryServices
{
	public class HouseOwnerRepositoryServices : RepositoryServices<HouseOwners, HouseOwnerVm>,IHouseOwnerRepositoroyServices
	{
		public HouseOwnerRepositoryServices(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
		{
		}
	}
}

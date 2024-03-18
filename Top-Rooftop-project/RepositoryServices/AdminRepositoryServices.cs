using AutoMapper;
using Top_Rooftop_project.Database;
using Top_Rooftop_project.Models;
using Top_Rooftop_project.ModelVm;
using Top_Rooftop_project.Services;

namespace Top_Rooftop_project.RepositoryServices
{
	public class AdminRepositoryServices : RepositoryServices<Admin, AdminVm>, IAdminRepositoryServices
	{
		public AdminRepositoryServices(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
		{
		}

        public Task InsertAsync(int id, PaymentVm paymentVm, CancellationToken cancelToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdatedAsync(int id, PaymentVm paymentVm, CancellationToken cancelToken)
        {
            throw new NotImplementedException();
        }
    }
}

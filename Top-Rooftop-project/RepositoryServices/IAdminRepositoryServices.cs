using Top_Rooftop_project.Models;
using Top_Rooftop_project.ModelVm;
using Top_Rooftop_project.Services;

namespace Top_Rooftop_project.RepositoryServices;

public interface IAdminRepositoryServices : IRepositoryServices<Admin, AdminVm>
{
    Task InsertAsync(int id, PaymentVm paymentVm, CancellationToken cancelToken);
    Task UpdatedAsync(int id, PaymentVm paymentVm, CancellationToken cancelToken);
}

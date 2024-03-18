using Microsoft.AspNetCore.Mvc;
using Top_Rooftop_project.ModelVm;
using Top_Rooftop_project.RepositoryServices;

namespace Top_Rooftop_project.Controllers;

public class AdminController : Controller
{
    private readonly IAdminRepositoryServices _services;

    public AdminController(IAdminRepositoryServices services)
    {
        _services = services;
    }

    public async Task<ActionResult<AdminVm>> Index(CancellationToken cancellationToken)
    {
        return View(await _services.GetAllAsync(cancellationToken));
    }



    [HttpGet]
    public async Task<ActionResult<AdminVm>> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new AdminVm());
        }
        else
        {
            var entiy = await _services.GetByIdAsync(id, cancellationToken);
            return View(entiy);
        }
    }
    [HttpPost]
    public async Task<ActionResult<AdminVm>> CreateOrEdit(int id, CancellationToken cancelToken, AdminVm adminVm)
    {
        if (id == 0)
        {
            if (ModelState.IsValid)
            {
              await _services.InsertAsync(id, adminVm, cancelToken);
                return Json(new { success = true, message = $"{adminVm.Email}'s Data added Successfuly" });
            }
        }
        else
        {
            await _services.UpdatedAsync(id, adminVm, cancelToken);
            return Json(new { success = true, message = $"{adminVm.Email}'s Data Updated Successfuly" });
        }
        return Json(new { success = false, message = $"{adminVm.Email}'s Data added Faild" });
    }
    public async Task<ActionResult<AdminVm>> Delted(int id, CancellationToken cancellationToken)
    {
        if (id != 0)
        {
            await _services.DeltedASync(id, cancellationToken);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public async Task<ActionResult<AdminVm>> Details(int id, CancellationToken cancellationToken)
    {
        var enti = await _services.GetByIdAsync(id, cancellationToken);
        return View(enti);

    }

}

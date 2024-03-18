using Microsoft.AspNetCore.Mvc;
using Top_Rooftop_project.Models;
using Top_Rooftop_project.ModelVm;
using Top_Rooftop_project.RepositoryServices;

namespace Top_Rooftop_project.Controllers;


public class HouseController : Controller
{
    private readonly IHouseOwnerRepositoroyServices _services;

    public HouseController(IHouseOwnerRepositoroyServices services)
    {
        _services = services;
    }

    public async Task<ActionResult<HouseOwnerVm>> Index(CancellationToken cancellationToken)
    {
        return View(await _services.GetAllAsync(cancellationToken));
    }


    [HttpGet]
    public async Task<ActionResult<HouseOwnerVm>> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new HouseOwnerVm());
        }
        else
        {
            var entiy = await _services.GetByIdAsync(id, cancellationToken);
            return View(entiy);
        }
    }
    [HttpPost]
    public async Task<ActionResult<HouseOwnerVm>> CreateOrEdit(int id, CancellationToken cancelToken, HouseOwnerVm houseOwnerVm)
    {
        if (id == 0)
        {
            if (ModelState.IsValid)
            {
                var enti = await _services.InsertAsync(id, houseOwnerVm, cancelToken);
                return Json(new { success = true, message = $"{houseOwnerVm.Name}'s Data added Successfuly" });
            }
        }
        else
        {
            await _services.UpdatedAsync(id, houseOwnerVm, cancelToken);
            return Json(new { success = true, message = $"{houseOwnerVm.Name}'s Data Updated Successfuly" });
        }
        return Json(new { success = false, message = $"{houseOwnerVm.Email}'s Data added faild" });
    }
    public async Task<ActionResult<HouseOwnerVm>> Delted(int id, CancellationToken cancellationToken)
    {
        if (id != 0)
        {
            await _services.DeltedASync(id, cancellationToken);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public async Task<ActionResult<HouseOwnerVm>> Details(int id, CancellationToken cancellationToken)
    {
        var enti = await _services.GetByIdAsync(id, cancellationToken);
        return View(enti);

    }
}

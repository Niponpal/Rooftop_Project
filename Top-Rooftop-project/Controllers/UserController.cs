using Microsoft.AspNetCore.Mvc;
using Top_Rooftop_project.Models;
using Top_Rooftop_project.ModelVm;
using Top_Rooftop_project.RepositoryServices;

namespace Top_Rooftop_project.Controllers;

public class UserController : Controller
{
    private readonly IUserRepositoryServices _services;

    public UserController(IUserRepositoryServices services)
    {
        _services = services;
    }

    public async Task<ActionResult<UserVm>> Index(CancellationToken cancellationToken)
    {
        return View(await _services.GetAllAsync(cancellationToken));
    }

    [HttpGet]
    public async Task<ActionResult<UserVm>> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new UserVm());
        }
        else
        {
            var entiy = await _services.GetByIdAsync(id, cancellationToken);
            return View(entiy);
        }
    }
    [HttpPost]
    public async Task<ActionResult<AdminVm>> CreateOrEdit(int id, CancellationToken cancelToken, UserVm userVm)
    {
        if (id == 0)
        {
            if (ModelState.IsValid)
            {
                await _services.InsertAsync(id, userVm, cancelToken);
                return Json(new { success = true, message = $"{userVm.UserName}'s Data added Successfuly" });
            }
        }
        else
        {
            await _services.UpdatedAsync(id, userVm, cancelToken);
            return Json(new { success = true, message = $"{userVm.UserName}'s Data Updated Successfuly" });
        }
        return Json(new { success = true, message = $"{userVm.UserName}'s Data added faild" });
    }
    public async Task<ActionResult<UserVm>> Delted(int id, CancellationToken cancellationToken)
    {
        if (id != 0)
        {
            await _services.DeltedASync(id, cancellationToken);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public async Task<ActionResult<UserVm>> Details(int id, CancellationToken cancellationToken)
    {
        var enti = await _services.GetByIdAsync(id, cancellationToken);
        return View(enti);

    }
}

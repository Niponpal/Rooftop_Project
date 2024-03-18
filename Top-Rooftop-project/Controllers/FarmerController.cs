using Microsoft.AspNetCore.Mvc;
using Top_Rooftop_project.Database;
using Top_Rooftop_project.Models;
using Top_Rooftop_project.ModelVm;
using Top_Rooftop_project.RepositoryServices;
using Top_Rooftop_project.Services;

namespace Top_Rooftop_project.Controllers;

public class FarmerController : Controller
{
	private readonly IFarmerRepositoryServices _services;

	public FarmerController(IFarmerRepositoryServices services)
	{
		_services = services;
	}

	public async Task<ActionResult<FarmerVm>> Index(CancellationToken cancellationToken)
	{
		return View(await _services.GetAllAsync(cancellationToken));
	}

    [HttpGet]
    public async Task<ActionResult<FarmerVm>> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new FarmerVm());
        }
        else
        {
            var entiy = await _services.GetByIdAsync(id, cancellationToken);
            return View(entiy);
        }
    }
    [HttpPost]
    public async Task<ActionResult<FarmerVm>> CreateOrEdit(int id, CancellationToken cancelToken, FarmerVm farmerVm, IFormFile photo, IFormFile photo2, IFormFile photo3)
    {
        if (id == 0)
        {
            if (ModelState.IsValid)
            {
                if (photo != null && photo.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image", photo.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        photo.CopyTo(stream);
                    }
                    farmerVm.Image1 = $"{photo.FileName}";
                }

                if (photo2 != null && photo2.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image", photo2.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        photo2.CopyTo(stream);
                    }
                    farmerVm.Image2 = $"{photo2.FileName}";
                }

                if (photo3 != null && photo3.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image", photo3.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        photo3.CopyTo(stream);
                    }
                    farmerVm.Image3 = $"{photo3.FileName}";
                }


               await _services.InsertAsync(id, farmerVm, cancelToken);
                return Json(new { success = true, message = $"{farmerVm.Name}'s Data added Successfuly" });
            }
        }
        else
        {
            if (photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image", photo.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }
                farmerVm.Image1 = $"{photo.FileName}";
            }

            if (photo2 != null && photo2.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image", photo2.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }
                farmerVm.Image2 = $"{photo2.FileName}";
            }

            if (photo3 != null && photo3.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image", photo3.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }
                farmerVm.Image3 = $"{photo3.FileName}";
            }

            await _services.UpdatedAsync(id, farmerVm, cancelToken);
            return Json(new { success = true, message = $"{farmerVm.Name}'s Data Updated Successfuly" });
        }
        return Json(new { success = false, message = $"{farmerVm.Name}'s Data added Faild" });
    }
    public async Task<ActionResult<FarmerVm>> Delted(int id, CancellationToken cancellationToken)
    {
        if (id != 0)
        {
            await _services.DeltedASync(id, cancellationToken);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public async Task<ActionResult<FarmerVm>> Details(int id, CancellationToken cancellationToken)
    {
        var enti = await _services.GetByIdAsync(id, cancellationToken);
        return View(enti);

    }

}

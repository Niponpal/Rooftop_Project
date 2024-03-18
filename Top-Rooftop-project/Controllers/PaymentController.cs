using Microsoft.AspNetCore.Mvc;
using Top_Rooftop_project.Models;
using Top_Rooftop_project.ModelVm;
using Top_Rooftop_project.RepositoryServices;

namespace Top_Rooftop_project.Controllers;


public class PaymentController : Controller
{
    private readonly IPaymentReposiotryServices _services;

    public PaymentController(IPaymentReposiotryServices services)
    {
        _services = services;
    }
    public async Task<ActionResult<PaymentVm>> Index(CancellationToken cancellationToken)
    {
        return View(await _services.GetAllAsync(cancellationToken));
    }



    [HttpGet]
    public async Task<ActionResult<PaymentVm>> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new PaymentVm());
        }
        else
        {
            var entiy = await _services.GetByIdAsync(id, cancellationToken);
            return View(entiy);
        }
    }
    [HttpPost]
    public async Task<ActionResult<PaymentVm>> CreateOrEdit(int id, CancellationToken cancelToken, PaymentVm  paymentVm) 
    {
        if (id == 0)
        {
            if (ModelState.IsValid)
            {
                 await _services.InsertAsync(id, paymentVm, cancelToken);
                return Json(new { success = true, message = $"{paymentVm.TransId}'s Data added Successfuly" });
            }
        }
        else
        {
            await _services.UpdatedAsync(id, paymentVm ,  cancelToken);
            return Json(new { success = true, message = $"{paymentVm.TransId}'s Data Updated Successfuly" });
        }
        return Json(new { success = false, message = $"{paymentVm.TransId}'s Data added faild" });
    }
    public async Task<ActionResult<PaymentVm>> Delted(int id, CancellationToken cancellationToken)
    {
        if (id != 0)
        {
            await _services.DeltedASync(id, cancellationToken);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public async Task<ActionResult<PaymentVm>> Details(int id, CancellationToken cancellationToken)
    {
        var enti = await _services.GetByIdAsync(id, cancellationToken);
        return View(enti);

    }


}

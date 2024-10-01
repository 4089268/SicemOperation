using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SicemOperation.Models;

namespace SicemOperation.Controllers;

[Authorize]
public class RecordController : Controller
{
    private readonly ILogger<RecordController> _logger;

    public RecordController(ILogger<RecordController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult NewRecord() {
        return View(new NewRecordRequest());
    }

    [HttpPost]
    public IActionResult NewRecord(NewRecordRequest request) {
        if(ModelState.IsValid){
            ViewBag.Message = "Not implementado.";
            ViewBag.MessageClass = "alert-warning";
            return View(request);
        }

        ViewBag.Message = "Datos no validos, verifique e intente de nuevo.";
        ViewBag.MessageClass = "alert-danger";
        return View();
    }

}

using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SicemOperation.Migrations;
using SicemOperation.Models;
using SicemOperation.Services;

namespace SicemOperation.Controllers;

[Authorize]
public class RecordController : Controller
{
    private readonly ILogger<RecordController> _logger;
    private readonly IncidenceService incidenceService;

    public RecordController(ILogger<RecordController> logger, IncidenceService incidenceService) {
        _logger = logger;
        this.incidenceService = incidenceService;
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
            this.incidenceService.RegisterIncidence(request);
            return RedirectToAction("Index");
        }

        ViewBag.Message = "Datos no validos, verifique e intente de nuevo.";
        ViewBag.MessageClass = "alert-danger";
        return View();
    }

}

using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.VisualBasic;
using SicemOperation.Models;
using SicemOperation.Services;

namespace SicemOperation.Controllers;

[Authorize]
public class RecordController : Controller
{
    private readonly ILogger<RecordController> _logger;
    private readonly IncidenceService incidenceService;
    private readonly ICompositeViewEngine viewEngine;

    public RecordController(ILogger<RecordController> logger, IncidenceService incidenceService, ICompositeViewEngine viewEngine) {
        this._logger = logger;
        this.incidenceService = incidenceService;
        this.viewEngine = viewEngine;
    }

    public IActionResult Index([FromQuery] int? year, [FromQuery] int? month) {

        DateTime targetDate;

        // Get the current date
        if( year != null && month != null){
            targetDate = new DateTime(year.Value, month.Value, 1);
        }else{
            targetDate = DateTime.Today;
        }
        
        ViewBag.TargetDate = targetDate.ToString("yyyy-MM-ddTHH:mm:ss");

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


    [Route("/record/testing/fake-data")]
    public IActionResult FakeDate([FromQuery] int year, [FromQuery] int c ){
        
        for( int i = 1; i<=12; i++){
            this.incidenceService.FakeData(year, i, c );
        }

        return Ok( new {
            Message = "Done",
            Year = year,
            Count = c
        });
    }

    #region partial views

    public ActionResult GetIncidentGrid(int year, int month ){

        // * get the incidents of the month
        try {
            var incidentsGrid = this.incidenceService.IncidentsTypesGetIncidentsGrid(year, month);
            return PartialView("~/Views/Record/Partials/IncidentGrid.cshtml", incidentsGrid);

        }catch(Exception err){
            this._logger.LogError(err, "Fail at get the incident grid data");
            ViewData["ErrorTitle"] = "Error resumen incidencias por mes";
            ViewData["ErrorMessage"] = "Hubo un error al obtener el resumen de incidencias, intente de nuevo o comuníquese con un administrador.";
            return PartialView("~/Views/Shared/ErrorAlert.cshtml", new ErrorViewModel());
        }
    }

    #endregion

}

using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.VisualBasic;
using SicemOperation.Migrations;
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

    public IActionResult Index() {

        // Get the current date
        DateTime targetDate = DateTime.Today;

        // Get the first day of the current month
        var firstDayOfMonth = new DateTime(targetDate.Year, targetDate.Month, 1);

        // Get the last day of the current month
        int daysInMonth = DateTime.DaysInMonth(targetDate.Year, targetDate.Month);
        var lastDayOfMonth = new DateTime(targetDate.Year, targetDate.Month, daysInMonth);

        ViewData["initialDay"] = firstDayOfMonth.Day;
        ViewData["endDay"] = lastDayOfMonth.Day;

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


    #region partial views
    
    [HttpPost]
    public IActionResult RenderGridIncidents(){
        string renderedView = RenderPartialViewToString("/Record/Partials/IncidentGrid", null);
        return Ok(renderedView);
    }

    public ActionResult GetIncidentGrid(){
        return PartialView("~/Views/Record/Partials/IncidentGrid.cshtml", new {
            InitialDate = 1,
            EndDate = 30
        });
    }

    private string RenderPartialViewToString(string viewName, object? model) {
        ViewData.Model = model;
        using (var sw = new StringWriter())
        {
            var viewResult = viewEngine.FindView(ControllerContext, viewName, false);
            if( viewResult.View == null){
                throw new Exception("View not found");
            }
            var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw, new HtmlHelperOptions());
            viewResult.View.RenderAsync(viewContext).Wait();
            return sw.GetStringBuilder().ToString();
        }
    }

    #endregion
}

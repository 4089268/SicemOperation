using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SicemOperation.Data;
using SicemOperation.Entities;
using SicemOperation.Models;
using SicemOperation.Models.DTO.CFE;

namespace SicemOperation.Controllers;

[Authorize]
[Route("/[controller]")]
public class CFERecordController : Controller
{
    private readonly ILogger<CFERecordController> _logger;
    private readonly SicemOperationContext sicemOperationContext;
    
    public CFERecordController(ILogger<CFERecordController> logger, SicemOperationContext sicemOperationContext)
    {
        this._logger = logger;
        this.sicemOperationContext = sicemOperationContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route("Consumo")]
    public IActionResult Consumo([FromQuery] int? af, [FromQuery] int? mf, [FromQuery] int? m)
    {
        // * get the period of the consumo
        var period = DateTime.Now;
        if(af != null && mf != null)
        {
            period = new DateTime(af.Value, mf.Value, 1);
        }

        // * check if the medidor is passed
        CFEMedidor? medidor = null;
        if(m != null)
        {
            medidor = this.sicemOperationContext.CFEMedidores.Find(m);
        }

        // * attempt to get the consume of the medidor in the target period
        CFEConsumo? cFEConsumo = null;
        if(medidor !=null)
        {
            cFEConsumo = this.sicemOperationContext.CFEConsumos.FirstOrDefault( item => item.IdMedidor == medidor.Id && item.Af == period.Year && item.Mf == period.Month);
        }

        if(cFEConsumo == null)
        {
            cFEConsumo = new CFEConsumo {
                IdMedidor = (medidor?.Id ?? 0),
                FechaInicio = new DateTime(period.Year, period.Month, 1),
                FechaFin = new DateTime(period.Year, period.Month, DateTime.DaysInMonth(period.Year, period.Month)),
                Consumo = 666,
                Importe = 666,
                Demanda = 666,
                Af = period.Year,
                Mf = period.Month,
                Kvarh = 666,
                FpPorc = 666,
                FpMon = 666,
                DapMon = 666,
            };
        }

        // * prepare the view
        var record = new ConsumoDTO()
        {
            Medidor = medidor,
            Consumo = cFEConsumo
        };
        return View(record);
    }


    #region partial views
    [Route("Medidores")]
    public ActionResult GetMedidoresGrid(int year, int month ){

        // * get the incidents of the month
        try
        {
            var medidores = this.sicemOperationContext.CFEMedidores.ToList();
            return PartialView("~/Views/CFERecord/Partials/MedidoresList.cshtml", medidores);

        }
        catch(Exception err)
    {
            this._logger.LogError(err, "Fail at get the incident grid data");
            ViewData["ErrorTitle"] = "Error resumen incidencias por mes";
            ViewData["ErrorMessage"] = "Hubo un error al obtener el resumen de incidencias, intente de nuevo o comuníquese con un administrador.";
            return PartialView("~/Views/Shared/ErrorAlert.cshtml", new ErrorViewModel());
        }
    }

    #endregion

}
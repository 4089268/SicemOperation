using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public IActionResult Consumo([FromQuery] int? af, [FromQuery] int? mf, [FromQuery] int? medidorId)
    {
        // * get the catalog of medidores
        var medidoresListItems = this.sicemOperationContext.CFEMedidores.Select(item => new SelectListItem(item.NumMedidor, item.Id.ToString())).ToList();

        // * get the period of the consumo
        var period = DateTime.Now;
        try
        {
            if(af != null && mf != null)
            {
                period = new DateTime(af.Value, mf.Value, 1);
            }
        }
        catch (System.Exception)
        {
            ViewBag.ErrorMessage = "El periodo seleccionado no es válido.";
            return View( new ConsumoDTO()
                {
                    Af = period.Year,
                    Mf = period.Month,
                    MedidoresListItems = medidoresListItems
                }
            );
        }

        // * check if the medidor is passed
        CFEMedidor? medidor = null;
        if(medidorId != null)
        {
            medidor = this.sicemOperationContext.CFEMedidores.Find(medidorId);
        }

        // * attempt to get the consume of the medidor in the target period
        CFEConsumo? cFEConsumo = null;
        if(medidor != null)
        {
            cFEConsumo = this.sicemOperationContext.CFEConsumos.FirstOrDefault( item => item.IdMedidor == medidor.Id && item.Af == period.Year && item.Mf == period.Month);
        }

        if(cFEConsumo == null & medidor != null)
        {
            cFEConsumo = new CFEConsumo {
                IdMedidor = medidor!.Id,
                FechaInicio = new DateTime(period.Year, period.Month, 1),
                FechaFin = new DateTime(period.Year, period.Month, DateTime.DaysInMonth(period.Year, period.Month)),
                Consumo = 0,
                Importe = 0,
                Demanda = 0,
                Af = period.Year,
                Mf = period.Month,
                Kvarh = 0,
                FpPorc = 0,
                FpMon = 0,
                DapMon = 0,
            };
        }

        // * prepare the view
        var record = new ConsumoDTO()
        {
            Af = period.Year,
            Mf = period.Month,
            MedidoresListItems = medidoresListItems,
            Medidor = medidor,
            Consumo = cFEConsumo
        };
        ViewBag.FormTitle = "Registrar Consumo del Periodo " + period.ToString("MMMM yyyy") + " para el Medidor " + (medidor != null ? medidor.NumMedidor : "No seleccionado");
        return View(record);
    }

    [HttpPost("store")]
    public IActionResult StoreConsumo([FromForm] ConsumoDTO consumoDTO)
    {
        // if(!ModelState.IsValid)
        // {
        //     return View("Consumo", consumoDTO);
        // }

        Console.WriteLine("ConsumoDTO: {0}", consumoDTO);
        return RedirectToAction("Consumo", new { af = consumoDTO.Af, mf = consumoDTO.Mf, medidorId = consumoDTO.MedidorId });
    }


}
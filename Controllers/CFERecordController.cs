using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SicemOperation.Data;
using SicemOperation.Entities;
using SicemOperation.Models;
using SicemOperation.Services;

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

    [Route("catalogos")]
    public IActionResult CatalogsIndex()
    {
        return View();
    }

    #region Tarifa
    [HttpGet("catalogos/tarifas")]
    public IActionResult TarifasIndex()
    {
        var tarifas = sicemOperationContext.CFETarifas.ToList();
        return View(tarifas);
    }

    [HttpGet("catalogos/tarifas/create")]
    public IActionResult TarifasCreate()
    {
        return View();
    }

    [HttpPost("catalogos/tarifas/create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TarifasCreate([Bind("Id,Nombre,Inactivo")] CFETarifa cfeTarifa)
    {
        if (ModelState.IsValid)
        {
            sicemOperationContext.CFETarifas.Add(cfeTarifa);
            await sicemOperationContext.SaveChangesAsync();
            return RedirectToAction("TarifasIndex");
        }
        return View(cfeTarifa);
    }

    [HttpGet("catalogos/tarifas/edit/{id}")]
    public async Task<IActionResult> TarifasEdit([FromRoute] int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cfeTarifa = await this.sicemOperationContext.CFETarifas.FindAsync(id);
        if (cfeTarifa == null)
        {
            return NotFound();
        }

        return View(cfeTarifa);
    }

    [HttpPost("catalogos/tarifas/edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TarifasEdit([FromRoute] int id, [Bind("Id,Nombre,Inactivo")] CFETarifa cfeTarifa)
    {
        if (id != cfeTarifa.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                this.sicemOperationContext.CFETarifas.Update(cfeTarifa);
                await this.sicemOperationContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!CFETarifaExists(cfeTarifa.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("TarifasIndex");
        }
        
        return View(cfeTarifa);
    }
    private bool CFETarifaExists(int id)
    {
        return this.sicemOperationContext.CFETarifas.Any(e => e.Id == id);
    }

    #endregion
}

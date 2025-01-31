using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SicemOperation.Data;
using SicemOperation.Entities;

namespace SicemOperation.Controllers;

[Authorize]
[Route("/CFERecord/Catalogos/[controller]")]
public class CFETarifaController : Controller
{
    private readonly ILogger<CFETarifaController> _logger;
    private readonly SicemOperationContext sicemOperationContext;
    
    public CFETarifaController(ILogger<CFETarifaController> logger, SicemOperationContext sicemOperationContext)
    {
        this._logger = logger;
        this.sicemOperationContext = sicemOperationContext;
    }

    
    public IActionResult Index()
    {
        var tarifas = sicemOperationContext.CFETarifas.ToList();
        return View(tarifas);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Inactivo")] CFETarifa cfeTarifa)
    {
        if (ModelState.IsValid)
        {
            sicemOperationContext.CFETarifas.Add(cfeTarifa);
            await sicemOperationContext.SaveChangesAsync();
            return RedirectToAction("TarifasIndex");
        }
        return View(cfeTarifa);
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit([FromRoute] int? id)
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

    [HttpPost("edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromRoute] int id, [Bind("Id,Nombre,Inactivo")] CFETarifa cfeTarifa)
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
            catch (Exception)
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

}

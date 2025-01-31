using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SicemOperation.Data;
using SicemOperation.Entities;

namespace SicemOperation.Controllers;

[Authorize]
[Route("/CFERecord/Catalogos/[controller]")]
public class CFEMedidorController : Controller
{
    private readonly ILogger<CFEMedidorController> _logger;
    private readonly SicemOperationContext sicemOperationContext;
    
    public CFEMedidorController(ILogger<CFEMedidorController> logger, SicemOperationContext sicemOperationContext)
    {
        this._logger = logger;
        this.sicemOperationContext = sicemOperationContext;
    }

    
    public IActionResult Index()
    {
        var medidores = this.sicemOperationContext.CFEMedidores
            .Include(m => m.Organismo)
            .Include(m => m.Tarifa)
            .Include(m => m.Proceso)
            .Include(m => m.Zona)
            .ToList();

        return View(medidores);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        LoadSelectListCatalogs();
        return View();
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromBody] CFEMedidor cfeMedidor)
    {
        if (ModelState.IsValid)
        {
            this.sicemOperationContext.Add(cfeMedidor);
            await this.sicemOperationContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        LoadSelectListCatalogs();
        return View(cfeMedidor);
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit([FromRoute] int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cfeMedidor = await this.sicemOperationContext.CFEMedidores.FindAsync(id);
        if (cfeMedidor == null)
        {
            return NotFound();
        }

        LoadSelectListCatalogs();
        return View(cfeMedidor);
    }

    [HttpPost("edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] CFEMedidor cFEMedidor)
    {
        if (id != cFEMedidor.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                this.sicemOperationContext.Update(cFEMedidor);
                await this.sicemOperationContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!CFEMedidorExists(cFEMedidor.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        
        LoadSelectListCatalogs();
        return View(cFEMedidor);
    }


    private void LoadSelectListCatalogs()
    {
        ViewBag.Organismos = this.sicemOperationContext.Organismos.Select(o => new SelectListItem { Value = o.Id.ToString(), Text = o.Nombre }).ToList();
        ViewBag.Tarifas = this.sicemOperationContext.CFETarifas.Where(e => e.Inactivo != true).Select(o => new SelectListItem { Value = o.Id.ToString(), Text = o.Nombre }).ToList();
        ViewBag.Procesos = this.sicemOperationContext.CFEProcesos.Select(o => new SelectListItem { Value = o.Id.ToString(), Text = o.Proceso }).ToList();
        ViewBag.Zonas = this.sicemOperationContext.CFEZonas.Select(o => new SelectListItem { Value = o.Id.ToString(), Text = o.Zona }).ToList();
    }

    private bool CFEMedidorExists(int id)
    {
        return sicemOperationContext.CFEMedidores.Any(e => e.Id == id);
    }

}

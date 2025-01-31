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
public class CFEProcesoController : Controller
{
    private readonly ILogger<CFEProcesoController> _logger;
    private readonly SicemOperationContext sicemOperationContext;
    
    public CFEProcesoController(ILogger<CFEProcesoController> logger, SicemOperationContext sicemOperationContext)
    {
        this._logger = logger;
        this.sicemOperationContext = sicemOperationContext;
    }

    
    public IActionResult Index()
    {
        var procesos = sicemOperationContext.CFEProcesos.ToList();
        return View(procesos);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Proceso")] CFEProceso cFEProceso)
    {
        if (ModelState.IsValid)
        {
            this.sicemOperationContext.CFEProcesos.Add(cFEProceso);
            await sicemOperationContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(cFEProceso);
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit([FromRoute] int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cFEProceso = await this.sicemOperationContext.CFEProcesos.FindAsync(id);
        if (cFEProceso == null)
        {
            return NotFound();
        }

        return View(cFEProceso);
    }

    [HttpPost("edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromRoute] int id, [Bind("Id,Proceso")] CFEProceso cFEProceso)
    {
        if (id != cFEProceso.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                this.sicemOperationContext.CFEProcesos.Update(cFEProceso);
                await this.sicemOperationContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!CFEProcesoExists(cFEProceso.Id))
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
        return View(cFEProceso);
    }

    private bool CFEProcesoExists(int id)
    {
        return sicemOperationContext.CFEProcesos.Any(e => e.Id == id);
    }

}

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
[Route("/catalogos/[controller]")]
public class CFEZonaController : Controller
{
    private readonly ILogger<CFEZonaController> _logger;
    private readonly SicemOperationContext sicemOperationContext;
    
    public CFEZonaController(ILogger<CFEZonaController> logger, SicemOperationContext sicemOperationContext)
    {
        this._logger = logger;
        this.sicemOperationContext = sicemOperationContext;
    }

    
    public IActionResult Index()
    {
        var zonas = sicemOperationContext.CFEZonas.ToList();
        return View(zonas);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Zona")] CFEZona cfeZona)
    {
        if (ModelState.IsValid)
        {
            this.sicemOperationContext.CFEZonas.Add(cfeZona);
            await sicemOperationContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(cfeZona);
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit([FromRoute] int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cfeZona = await this.sicemOperationContext.CFEZonas.FindAsync(id);
        if (cfeZona == null)
        {
            return NotFound();
        }

        return View(cfeZona);
    }

    [HttpPost("edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromRoute] int id, [Bind("Id,Zona")] CFEZona cfeZona)
    {
        if (id != cfeZona.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                this.sicemOperationContext.CFEZonas.Update(cfeZona);
                await this.sicemOperationContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!CFEZonaExists(cfeZona.Id))
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
        return View(cfeZona);
    }

    private bool CFEZonaExists(int id)
    {
        return sicemOperationContext.CFEZonas.Any(e => e.Id == id);
    }

}

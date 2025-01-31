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

    [Route("Catalogos")]
    public IActionResult CatalogsIndex()
    {
        return View();
    }
}

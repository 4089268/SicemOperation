using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SicemOperation.Models;

namespace SicemOperation.Controllers;

public class RecordController : Controller
{
    private readonly ILogger<RecordController> _logger;

    public RecordController(ILogger<RecordController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult NewRecord()
    {
        return View();
    }

}

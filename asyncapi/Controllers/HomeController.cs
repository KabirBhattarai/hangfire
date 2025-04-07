using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using asyncapi.Models;
using Hangfire;

namespace asyncapi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public void BulkImportSimulation()
    {
        Thread.Sleep(10000);
        Console.WriteLine("Bulk import completed");
    }

    [HttpGet("api/task/bulk-import")]
    public IActionResult BulkAsyncImport()
    {
        BackgroundJob.Enqueue(() => BulkImportSimulation());
        return View();
    }
    
    [HttpGet("api/task/bulk-import/sync")]
    public IActionResult BulkImport()
    {
        BulkImportSimulation();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
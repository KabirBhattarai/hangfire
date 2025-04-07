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
        Task.Delay(TimeSpan.FromSeconds(60));
        _logger.LogInformation("Data Processing Completed!");
    }

    public IActionResult BulkAsyncImport()
    {
        BackgroundJob.Enqueue(() => BulkImportSimulation());
        return Accepted("Bulk Import Started");
    }
    
    public IActionResult BulkImport()
    {
        BulkImportSimulation();
        return Accepted("Bulk Import Started");
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
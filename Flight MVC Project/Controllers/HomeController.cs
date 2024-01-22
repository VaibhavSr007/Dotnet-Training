using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using flightProject.Models;
using System.Data.Common;

namespace flightProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    private Ace52024Context db = new Ace52024Context();
    

    public IActionResult Index()
    {   
        var cid = HttpContext.Session.GetInt32("CustomerId");
        
        if(cid == null){
            return RedirectToAction("Login", "Customer");
        }
        else{
            var user = db.VsCustomers.Where(x => x.CustomerId == cid).Select(x => x).SingleOrDefault();
            ViewBag.username = user.CustomerName;
            ViewBag.CustomerId = cid;
            ViewBag.isAdmin = user.CustomerName;
            return View();
        }
    }

    public IActionResult Privacy()
    {
        var cid = HttpContext.Session.GetInt32("CustomerId");
        if(cid == null){
            return RedirectToAction("Login", "Customer");
        }
        else{
            var user = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
            ViewBag.isAdmin = user.CustomerName;
            return View();
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

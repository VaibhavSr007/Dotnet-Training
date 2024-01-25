using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using flightProject.Models;
using System.Data.Common;
using Newtonsoft.Json;

namespace flightProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // private Ace52024Context db = new Ace52024Context();
    

    public async Task<ActionResult> Index()
    {   
        var cid = HttpContext.Session.GetInt32("CustomerId");
        
        if(cid == null){
            return RedirectToAction("Login", "Customer");
        }
        else{

            Customers user = new Customers();
            using (var httpClient1 = new HttpClient())
            {
                using (var response1 = await httpClient1.GetAsync("http://localhost:5071/api/Customer/" + cid))
                {
                    string apiResponse = await response1.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<Customers>(apiResponse);
                }
            }
            // var user = db.VsCustomers.Where(x => x.CustomerId == cid).Select(x => x).SingleOrDefault();
            ViewBag.username = user.CustomerName;
            ViewBag.CustomerId = cid;
            ViewBag.isAdmin = user.CustomerName;
            return View();
        }
    }

    public async Task<ActionResult> Privacy()
    {
        var cid = HttpContext.Session.GetInt32("CustomerId");
        if(cid == null){
            return RedirectToAction("Login", "Customer");
        }
        else{
            Customers user = new Customers();
            using (var httpClient1 = new HttpClient())
            {
                using (var response1 = await httpClient1.GetAsync("http://localhost:5071/api/Customer/" + cid))
                {
                    string apiResponse = await response1.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<Customers>(apiResponse);
                }
            }
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

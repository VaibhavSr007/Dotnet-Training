using flightProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Data.SqlClient;

namespace flightProject.Controllers{
    
    public class FlightController : Controller{

        public static Ace52024Context db;
        public FlightController(Ace52024Context _db)
        {
            db=_db;
        }


        public ActionResult SearchFlight(){
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                var user = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
                ViewBag.isAdmin = user.CustomerName;
                ViewBag.Flightsources=new SelectList(db.VsFlights,"Src","Src");
                ViewBag.Flightdestinations=new SelectList(db.VsFlights,"Dest","Dest");
                return View();
            }
        }

        [HttpPost]
        public ActionResult SearchFlight(VsSearch s){
            var cid = HttpContext.Session.GetInt32("CustomerId");

            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                var user = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
                ViewBag.isAdmin = user.CustomerName;
                HttpContext.Session.SetString("srcc",s.SearchSrc);
                HttpContext.Session.SetString("destt",s.SearchDest);
                return RedirectToAction("GetAllFlights");
                
            }
        }
        // Get All Flights
        public ActionResult GetAllFlights(){
            var cid = HttpContext.Session.GetInt32("CustomerId");
            
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                var user = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
                ViewBag.isAdmin = user.CustomerName;
                var src = HttpContext.Session.GetString("srcc");
                var dest = HttpContext.Session.GetString("destt");
                ViewBag.Sourcevs = src;
                ViewBag.Destinationvs = dest;
                var res = db.VsFlights.Where(x=> x.Src == src && x.Dest == dest).Select(x=>x).ToList();
                return View(res);
                // return View(db.VsFlights);
            }
        }


        // Book a Flight Ticket

        public ActionResult SuccessBooking(){
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                var user = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
                ViewBag.isAdmin = user.CustomerName;
                ViewBag.cid = cid;
                return View();
            }
        }
        public ActionResult BookFlight(int flightid){
            // here we will set the flightId in the session storage
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                var user = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
                ViewBag.isAdmin = user.CustomerName;
                ViewBag.fid = flightid;
                ViewBag.Rate = db.VsFlights.Where(x=>x.FlightId == flightid).Select(x=>x).SingleOrDefault().Rate;
                ViewBag.cid = HttpContext.Session.GetInt32("CustomerId");

                return View();
            }
        }
        [HttpPost]
        public ActionResult BookFlight(VsBookingDetail b){

            db.VsBookingDetails.Add(b);  
            db.SaveChanges();
            // here we will reset the flight id in the session storage
            return RedirectToAction("SuccessBooking");
        }

        

        // Add new Flight
        public ActionResult AddNewFlight(){
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
        [HttpPost]
        public ActionResult AddNewFlight(VsFlight f){
            db.VsFlights.Add(f);  
            db.SaveChanges();
            return RedirectToAction("GetAllFlights","Admin");
        }
    }
}
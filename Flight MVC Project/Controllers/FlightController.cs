using flightProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;

namespace flightProject.Controllers{
    
    public class FlightController : Controller{

        public static Ace52024Context db;
        public FlightController(Ace52024Context _db)
        {
            db=_db;
        }

        // Get All Flights
        public ActionResult GetAllFlights(){
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                return View(db.VsFlights);
            }
        }


        // Book a Flight Ticket

        public ActionResult SuccessBooking(){
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
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
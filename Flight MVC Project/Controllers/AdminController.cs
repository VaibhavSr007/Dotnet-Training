using flightProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace flightProject.Controllers{

    public class AdminController : Controller{

        public static Ace52024Context db;
        public AdminController(Ace52024Context _db)
        {
            db=_db;
        }


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
        
        public ActionResult GetAllFlights(){
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                var user = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
                ViewBag.isAdmin = user.CustomerName;
                return View(db.VsFlights);
            }
        }

        public ActionResult FlightEdit(int fid){
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                var user = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
                ViewBag.isAdmin = user.CustomerName;
                var f = db.VsFlights.Where(x=>x.FlightId == fid).Select(x=>x).SingleOrDefault();
                return View(f);
            }
        }

        [HttpPost]
        public ActionResult FlightEdit(VsFlight f){
            db.VsFlights.Update(f);
            db.SaveChanges();
            return RedirectToAction("GetAllFlights");
        }

        public ActionResult FlightDetails(int fid){
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                var user = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
                ViewBag.isAdmin = user.CustomerName;
                var s = db.VsFlights.Where(x=>x.FlightId == fid).Select(x=>x).SingleOrDefault();
                return View(s);
            }
        }

        public ActionResult FlightDelete(int id){
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                var user = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
                ViewBag.isAdmin = user.CustomerName;
                var s = db.VsFlights.Where(x=>x.FlightId == id).Select(x=>x).SingleOrDefault();
                return View(s);
            }
        }

        [HttpPost]
        [ActionName("FlightDelete")]
        public ActionResult  FlightDeleteConfirmed(int id){
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                var s = db.VsFlights.Where(x=>x.FlightId == id).Select(x=>x).SingleOrDefault();
                if(s != null){
                    var bookingRowDel = db.VsBookingDetails.Where(x=>x.FlightId == id).ToList();
                    db.VsBookingDetails.RemoveRange(bookingRowDel);
                    db.VsFlights.Remove(s);
                    db.SaveChanges();
                }
                return RedirectToAction("GetAllFlights");
            }
        }



        public ActionResult GetAllCustomers(){
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                var user = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
                ViewBag.isAdmin = user.CustomerName;
                return View(db.VsCustomers);
            }
        }

        public ActionResult CustomerDelete(int id){
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                var user = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
                ViewBag.isAdmin = user.CustomerName;
                var s = db.VsCustomers.Where(x=>x.CustomerId == id).Select(x=>x).SingleOrDefault();
                return View(s);
            }
        }

        [HttpPost]
        [ActionName("CustomerDelete")]

        public ActionResult  CustomerDeleteConfirmed(int id){
            var s = db.VsCustomers.Where(x=>x.CustomerId == id).Select(x=>x).SingleOrDefault();
            if(s != null){
                var bookingRowDel = db.VsBookingDetails.Where(x=>x.CustomerId == id).ToList();
                db.VsBookingDetails.RemoveRange(bookingRowDel);
                db.VsCustomers.Remove(s);
                db.SaveChanges();
            }
            return RedirectToAction("GetAllCustomers");
        }

        

    }
}
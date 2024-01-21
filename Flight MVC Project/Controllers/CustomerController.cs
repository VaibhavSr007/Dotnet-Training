using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using flightProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace flightProject.Controllers{

    public class CustomerController : Controller{

        public static Ace52024Context db;
        public CustomerController(Ace52024Context _db)
        {
            db=_db;
        }

        // Login
        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public IActionResult Login(VsCustomer c){
            var user = db.VsCustomers.Where(x => x.CustomerEmail == c.CustomerEmail && x.CustomerPass == ComputeMD5Hash(c.CustomerPass)).Select(x=>x).SingleOrDefault();
            if(user!=null){
                HttpContext.Session.SetInt32("CustomerId", user.CustomerId);
                return RedirectToAction("Index", "Home");
            }
            else{
                return View();
            }
        }

        // Logout
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // Register

        public static string ComputeMD5Hash(string input){
            using (MD5 md5 = MD5.Create()){

                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();

                for(int i=0; i<hashBytes.Length; i++){
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }
        public IActionResult Register(){
            return View();
        }

        [HttpPost]
        public IActionResult Register(VsCustomer c){
            c.CustomerPass = ComputeMD5Hash(c.CustomerPass);
            db.VsCustomers.Add(c);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

        // All booked flights of customer
        public ActionResult AllBookings(int customerId){
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                var s = db.VsBookingDetails.Include(x=>x.Flight).Where(x=>x.CustomerId == customerId).Select(x=>x).ToList();
                return View(s);
            }
        }

        // Deleting a booking for customer
        public ActionResult DeleteBooking(int id){
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                var s = db.VsBookingDetails.Where(x=>x.BookingId == id).Select(x=>x).SingleOrDefault();
                ViewBag.cid = cid;
                return View(s);
            }
        }

        [HttpPost]
        [ActionName("DeleteBooking")]

        public ActionResult DeleteBookingConfirmed(int id){
            var s = db.VsBookingDetails.Where(x=>x.BookingId == id).Select(x=>x).SingleOrDefault();
            if(s != null){
                db.VsBookingDetails.Remove(s);
                db.SaveChanges();
            }
            return RedirectToAction("SuccessCancelling");
        }

        public ActionResult SuccessCancelling(){
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                ViewBag.cid = cid;
                return View();
            }
        }

        // Booking details of particular booking
        public ActionResult BookingDetails(int bkid){
            var bk = db.VsBookingDetails.Include(x=>x.Flight).Where(x=>x.BookingId == bkid).Select(x=>x).SingleOrDefault();
            return View(bk);
        }

        // details of particular customer
        public ActionResult CustomerDetail(){

            var cid = HttpContext.Session.GetInt32("CustomerId");
            if(cid == null){
                return RedirectToAction("Login");
            }
            else{
                var s = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
                return View(s);
            }
        }

        // Edit Customer Details

        public ActionResult EditCustomerDetail(){

            var cid = HttpContext.Session.GetInt32("CustomerId");
            if(cid == null){
                return RedirectToAction("Login");
            }
            else{
                var s = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
                return View(s);
            }
        }

        [HttpPost]
        public ActionResult EditCustomerDetail(VsCustomer c){
            c.CustomerPass = ComputeMD5Hash(c.CustomerPass);
            db.VsCustomers.Update(c);
            db.SaveChanges();
            return RedirectToAction("CustomerDetail");
        }


    }
}
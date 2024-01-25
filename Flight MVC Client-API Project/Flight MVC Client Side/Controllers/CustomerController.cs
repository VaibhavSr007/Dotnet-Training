using System.Drawing;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using flightProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace flightProject.Controllers{

    public class CustomerController : Controller{

        // public static Ace52024Context db;
        // public CustomerController(Ace52024Context _db)
        // {
        //     db=_db;
        // }

        // Login
        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(Customers c){

            c.CustomerPass = ComputeMD5Hash(c.CustomerPass);

            using (var httpClient = new HttpClient()){

                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5071/api/Customer/Login", content);

                if(response.IsSuccessStatusCode){
                    
                    var msg = await response.Content.ReadAsStringAsync();
                    int inp;
                    if(int.TryParse(msg, out int intValue)){
                        inp = intValue;
                    }
                    else{
                        inp = 0;
                    }

                    Customers c1 = new Customers();
                    using (var httpClient1 = new HttpClient())
                    {
                        using (var response1 = await httpClient1.GetAsync("http://localhost:5071/api/Customer/" + inp))
                        {
                            string apiResponse = await response1.Content.ReadAsStringAsync();
                            c1 = JsonConvert.DeserializeObject<Customers>(apiResponse);
                        }
                    }
                    ViewBag.uname = c1.CustomerName;

                    HttpContext.Session.SetInt32("CustomerId", c1.CustomerId);
                    HttpContext.Session.SetString("UserName", c1.CustomerName);
                    return RedirectToAction("Index", "Home");
                }
                else{
                    return View();
                }
            }

            // var user = db.VsCustomers.Where(x => x.CustomerEmail == c.CustomerEmail && x.CustomerPass == ComputeMD5Hash(c.CustomerPass)).Select(x=>x).SingleOrDefault();
            // if(user!=null){
            //     HttpContext.Session.SetInt32("CustomerId", user.CustomerId);
            //     HttpContext.Session.SetString("UserName", user.CustomerName);
            //     return RedirectToAction("Index", "Home");
            // }
            // else{
            //     return View();
            // }
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
        public async Task<ActionResult> Register(Customers c){
            c.CustomerPass = ComputeMD5Hash(c.CustomerPass);
            
            Customers fltobj = new Customers();
            using (var httpClient = new HttpClient()){

                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:5071/api/Customer", content)){

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fltobj = JsonConvert.DeserializeObject<Customers>(apiResponse);
                }

                return RedirectToAction("Login");
            }
            
            // db.VsCustomers.Add(c);
            // db.SaveChanges();
            // return RedirectToAction("Login");
        }

        // All booked flights of customer by API
        public async Task<ActionResult> AllBookings(int customerId){
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


                List<bookings> b = new List<bookings>();

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("http://localhost:5071/api/Booking/AllBookings?id=" + customerId);

                if(Res.IsSuccessStatusCode){
                    var StRes = Res.Content.ReadAsStringAsync().Result;

                    b = JsonConvert.DeserializeObject<List<bookings>>(StRes);
                }

                return View(b);

                // var s = db.VsBookingDetails.Include(x=>x.Flight).Where(x=>x.CustomerId == customerId).Select(x=>x).ToList();
                // return View(s);
            }
        }

        // Deleting a booking for customer
        public async Task<ActionResult> DeleteBooking(int id){
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


                TempData["bid"] = id;
                bookings s = new bookings();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:5071/api/Booking/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        s = JsonConvert.DeserializeObject<bookings>(apiResponse);
                    }
                }

                ViewBag.cid = cid;
                return View(s);
                // var s = db.VsBookingDetails.Where(x=>x.BookingId == id).Select(x=>x).SingleOrDefault();
                // return View(s);
            }
        }

        [HttpPost]
        [ActionName("DeleteBooking")]

        public async Task<ActionResult> DeleteBookingConfirmed(bookings b){
            
            int bid = Convert.ToInt32(TempData["bid"]);
                // var bookingRowDel = await db.VsBookingDetails.Where(x=>x.FlightId == flid).ToListAsync();
                // db.VsBookingDetails.RemoveRange(bookingRowDel);
                
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5071/api/Booking/" + bid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            
            
            // var s = db.VsBookingDetails.Where(x=>x.BookingId == id).Select(x=>x).SingleOrDefault();
            // if(s != null){
            //     db.VsBookingDetails.Remove(s);
            //     db.SaveChanges();
            // }
            return RedirectToAction("SuccessCancelling");
        }

        public async Task<ActionResult> SuccessCancelling(){
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
                ViewBag.cid = cid;
                return View();
            }
        }

        // Booking details of particular booking
        public async Task<ActionResult> BookingDetails(int bkid){
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

                bookings b = new bookings();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:5071/api/Booking/" + bkid))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        b = JsonConvert.DeserializeObject<bookings>(apiResponse);
                    }
                }
                return View(b);

                // var bk = db.VsBookingDetails.Include(x=>x.Flight).Where(x=>x.BookingId == bkid).Select(x=>x).SingleOrDefault();
                // return View(bk);
            }
        }

        // details of particular customer
        public async Task<ActionResult> CustomerDetail(){

            var cid = HttpContext.Session.GetInt32("CustomerId");
            if(cid == null){
                return RedirectToAction("Login");
            }
            else{
                // var user = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();

                Customers c = new Customers();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:5071/api/Customer/" + cid))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        c = JsonConvert.DeserializeObject<Customers>(apiResponse);
                    }
                }
                ViewBag.uname = c.CustomerName;
                ViewBag.isAdmin = c.CustomerName;
                
                return View(c);

                // var s = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
                // return View(s);
            }
        }

        // Edit Customer Details

        public async Task<ActionResult> EditCustomerDetail(){

            var cid = HttpContext.Session.GetInt32("CustomerId");
            if(cid == null){
                return RedirectToAction("Login");
            }
            else{

                Customers c = new Customers();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:5071/api/Customer/" + cid))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        c = JsonConvert.DeserializeObject<Customers>(apiResponse);
                    }
                }
                ViewBag.uname = c.CustomerName;
                ViewBag.isAdmin = c.CustomerName;
                return View(c);

                // var s = db.VsCustomers.Where(x=>x.CustomerId == cid).Select(x=>x).SingleOrDefault();
                // return View(s);
            }
        }

        [HttpPost]
        public async Task<ActionResult> EditCustomerDetail(Customers c){
            c.CustomerPass = ComputeMD5Hash(c.CustomerPass);

            Customers RcvdCustomer = new Customers();

            using (var httpClient = new HttpClient())
            {
                
                int id = c.CustomerId;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:5071/api/Customer/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    RcvdCustomer = JsonConvert.DeserializeObject<Customers>(apiResponse);
                }
            }

            // db.VsCustomers.Update(c);
            // db.SaveChanges();
            return RedirectToAction("CustomerDetail");
        }


    }
}
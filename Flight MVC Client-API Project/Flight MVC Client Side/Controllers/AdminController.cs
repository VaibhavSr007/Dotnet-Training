using System.Net.Http.Headers;
using System.Text;
using flightProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace flightProject.Controllers{

    public class AdminController : Controller{

        // public static Ace52024Context db;
        // public AdminController(Ace52024Context _db)
        // {
        //     db=_db;
        // }


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
                ViewBag.username = user.CustomerName;
                ViewBag.CustomerId = cid;
                ViewBag.isAdmin = user.CustomerName;
                return View();
            }
        }
        
        public async Task<ActionResult> GetAllFlights(){
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

                List<flights> f = new List<flights>();

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("http://localhost:5071/api/Flight");

                if(Res.IsSuccessStatusCode){
                    var StRes = Res.Content.ReadAsStringAsync().Result;

                    f = JsonConvert.DeserializeObject<List<flights>>(StRes);
                }

                return View(f);
                // return View(db.VsFlights);
            }
        }

        public async Task<ActionResult> FlightEdit(int fid){
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
                // var f = db.VsFlights.Where(x=>x.FlightId == fid).Select(x=>x).SingleOrDefault();
                // return View(f);

                flights f = new flights();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:5071/api/Flight/" + fid))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        f = JsonConvert.DeserializeObject<flights>(apiResponse);
                    }
                }
                return View(f);
            }
        }

        [HttpPost]
        public async Task<ActionResult> FlightEdit(flights f){
            // db.VsFlights.Update(f);
            // db.SaveChanges();

            flights RcvdFlight = new flights();

            using (var httpClient = new HttpClient())
            {
                
                int id = f.FlightId;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(f), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:5071/api/Flight/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    RcvdFlight = JsonConvert.DeserializeObject<flights>(apiResponse);
                }
            }

            return RedirectToAction("GetAllFlights");
        }

        public async Task<ActionResult> FlightDetails(int fid){
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
                

                flights f = new flights();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:5071/api/Flight/" + fid))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        f = JsonConvert.DeserializeObject<flights>(apiResponse);
                    }
                }
                return View(f);

                // var s = db.VsFlights.Where(x=>x.FlightId == fid).Select(x=>x).SingleOrDefault();
                // return View(f);
            }
        }

        public async Task<ActionResult> FlightDelete(int id){
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

                TempData["flid"] = id;
                flights fl = new flights();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:5071/api/Flight/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        fl = JsonConvert.DeserializeObject<flights>(apiResponse);
                    }
                }
                return View(fl);

                // var s = db.VsFlights.Where(x=>x.FlightId == id).Select(x=>x).SingleOrDefault();
                // return View(s);
            }
        }

        [HttpPost]
        [ActionName("FlightDelete")]
        public async Task<ActionResult>  FlightDeleteConfirmed(flights f){
            var cid = HttpContext.Session.GetInt32("CustomerId");
        
            if(cid == null){
                return RedirectToAction("Login", "Customer");
            }
            else{
                // var s = db.VsFlights.Where(x=>x.FlightId == id).Select(x=>x).SingleOrDefault();
    
                int flid = Convert.ToInt32(TempData["flid"]);
                // var bookingRowDel = await db.VsBookingDetails.Where(x=>x.FlightId == flid).ToListAsync();
                // db.VsBookingDetails.RemoveRange(bookingRowDel);
                
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync("http://localhost:5071/api/Flight/" + flid))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }

                return RedirectToAction("GetAllFlights");

                // db.VsFlights.Remove(s);
                // db.SaveChanges();
                
                // return RedirectToAction("GetAllFlights");
            }
        }



        public async Task<ActionResult> GetAllCustomers(){
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

                List<Customers> c = new List<Customers>();

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("http://localhost:5071/api/Customer");

                if(Res.IsSuccessStatusCode){
                    var StRes = Res.Content.ReadAsStringAsync().Result;

                    c = JsonConvert.DeserializeObject<List<Customers>>(StRes);
                }

                return View(c);
                

                // return View(db.VsCustomers);
            }
        }

        public async  Task<ActionResult> CustomerDelete(int id){
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

                TempData["cusid"] = id;
                Customers c = new Customers();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:5071/api/Customer/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        c = JsonConvert.DeserializeObject<Customers>(apiResponse);
                    }
                }
                return View(c);
                // var s = db.VsCustomers.Where(x=>x.CustomerId == id).Select(x=>x).SingleOrDefault();
                // return View(s);
            }
        }

        [HttpPost]
        [ActionName("CustomerDelete")]

        public async Task<ActionResult>  CustomerDeleteConfirmed(Customers c){
            // var s = db.VsCustomers.Where(x=>x.CustomerId == id).Select(x=>x).SingleOrDefault();

            int cid = Convert.ToInt32(TempData["cusid"]);
            
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5071/api/Customer/" + cid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("GetAllCustomers");

            // if(s != null){
            //     var bookingRowDel = db.VsBookingDetails.Where(x=>x.CustomerId == id).ToList();
            //     db.VsBookingDetails.RemoveRange(bookingRowDel);
            //     db.VsCustomers.Remove(s);
            //     db.SaveChanges();
            // }
            // return RedirectToAction("GetAllCustomers");
        }

        

    }
}
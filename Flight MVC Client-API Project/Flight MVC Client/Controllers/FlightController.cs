using System.Net.Http.Headers;
using System.Text;
using flightProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace flightProject.Controllers{
    
    public class FlightController : Controller{

        public static Ace52024Context db;
        public FlightController(Ace52024Context _db)
        {
            db=_db;
        }


        public async  Task<ActionResult> SearchFlight(){
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
                ViewBag.Flightsources=new SelectList(db.VsFlights,"Src","Src");
                ViewBag.Flightdestinations=new SelectList(db.VsFlights,"Dest","Dest");
                return View();
            }
        }

        [HttpPost]
        public async  Task<ActionResult> SearchFlight(VsSearch s){
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
                HttpContext.Session.SetString("srcc",s.SearchSrc);
                HttpContext.Session.SetString("destt",s.SearchDest);
                return RedirectToAction("GetAllFlights");
                
            }
        }
        // Getting All Flights for a user based on input with API *************
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
                var src = HttpContext.Session.GetString("srcc");
                var dest = HttpContext.Session.GetString("destt");
                ViewBag.Sourcevs = src;
                ViewBag.Destinationvs = dest;


                List<flights> f = new List<flights>();

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("http://localhost:5071/api/Flight/search?id=" + src + "-" + dest);

                if(Res.IsSuccessStatusCode){
                    var StRes = Res.Content.ReadAsStringAsync().Result;

                    f = JsonConvert.DeserializeObject<List<flights>>(StRes);
                }

                return View(f);

                // var res = db.VsFlights.Where(x=> x.Src == src && x.Dest == dest).Select(x=>x).ToList();
                // return View(res);
            }
        }


        // Book a Flight Ticket
        public async Task<ActionResult> SuccessBooking(){
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
        public async Task<ActionResult> BookFlight(int flightid){
            // here we will set the flightId in the session storage
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
                ViewBag.fid = flightid;

                flights f = new flights();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:5071/api/Flight/" + flightid))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        f = JsonConvert.DeserializeObject<flights>(apiResponse);
                    }
                }

                ViewBag.Rate = f.Rate;
                ViewBag.cid = HttpContext.Session.GetInt32("CustomerId");

                return View();
            }
        }
        [HttpPost]
        public async  Task<ActionResult> BookFlight(bookings b){
            
            bookings bkobj = new bookings();
            using (var httpClient = new HttpClient()){

                StringContent content = new StringContent(JsonConvert.SerializeObject(b), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:5071/api/Booking", content)){

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bkobj = JsonConvert.DeserializeObject<bookings>(apiResponse);
                }

                return RedirectToAction("SuccessBooking");
            }

            // db.VsBookingDetails.Add(b);  
            // db.SaveChanges();
            // here we will reset the flight id in the session storage
            // return RedirectToAction("SuccessBooking");
        }

        

        // Add new Flight
        public async Task<ActionResult> AddNewFlight(){
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
        [HttpPost]
        // public ActionResult AddNewFlight(VsFlight f){
        //     db.VsFlights.Add(f);  
        //     db.SaveChanges();
        //     return RedirectToAction("GetAllFlights","Admin");
        // }

        // adding flights from API
        public async Task<ActionResult> AddNewFlight(flights f){

            flights fltobj = new flights();
            using (var httpClient = new HttpClient()){

                StringContent content = new StringContent(JsonConvert.SerializeObject(f), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:5071/api/Flight", content)){

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fltobj = JsonConvert.DeserializeObject<flights>(apiResponse);
                }

                return RedirectToAction("GetAllFlights", "Admin");
            }

        }
    }
}
using loginmvcex.Models;
using Microsoft.AspNetCore.Mvc;

namespace loginmvcex.Controllers{


    public class LoginController : Controller{

        public static Ace52024Context db;
        
        //Dependency Injection  in constructor
        public LoginController(Ace52024Context _db)
        {
            db=_db;
        }

        // all users GET
        public ActionResult GetAllUsers(){
            ViewBag.Username = HttpContext.Session.GetString("uname");
            
            if(ViewBag.Username != null){
                return View(db.UserVais);
            }
            else{
                return RedirectToAction("Login");
            }
        }

        // Login
        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserVai u){
            var s = db.UserVais.Where(x=>x.Email==u.Email && x.Pass==u.Pass).Select(x=>x).SingleOrDefault();
            if(s != null){
                HttpContext.Session.SetString("uname",s.Username);
                return RedirectToAction("GetAllUsers");
            }
            else{
                return View();
            }
        }

        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    } 
}
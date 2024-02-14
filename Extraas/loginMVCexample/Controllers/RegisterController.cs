using loginmvcex.Models;
using Microsoft.AspNetCore.Mvc;

namespace loginmvcex.Controllers{


    public class RegisterController : Controller{

        public static Ace52024Context db;
        
        //Dependency Injection  in constructor
        public RegisterController(Ace52024Context _db)
        {
            db=_db;
        }


        // Register
        public IActionResult Register(){
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserVai u){
            db.UserVais.Add(u);
            db.SaveChanges();
            return RedirectToAction("Login", "Login");
        }

    } 
}
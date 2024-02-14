using firstmvcprj.Models;
using Microsoft.AspNetCore.Mvc;

namespace firstmvcprj.Controllers{

    public class BankController : Controller{

        // public static Ace52024Context db = new Ace52024Context();
        

        public static Ace52024Context db;
        
        //Dependency Injection  in constructor
        public BankController(Ace52024Context _db)
        {
            db=_db;
        }


        // Read all at once
        public ActionResult GetAllAcounts(){
            var b = db.SbAccountvs;
            return View(b);
            // return View(db.SbAccountvs);
        }


        //  Create
        [HttpGet]
        public ActionResult AddNewAccount(){
            return View();
        }

        [HttpPost] // button click logic
        public ActionResult AddNewAccount(SbAccountv sb){
            db.SbAccountvs.Add(sb);
            db.SaveChanges();
            return  RedirectToAction("GetAllAcounts");
        }

        // Read / Get a speacified accunt details
        public ActionResult Details(int accno){
            var s = db.SbAccountvs.Where(x=>x.AccountNumber == accno).Select(x=>x).SingleOrDefault();
            return View(s);
        }

        // Update
        public ActionResult Edit(int accno){
            var s = db.SbAccountvs.Where(x=>x.AccountNumber == accno).Select(x=>x).SingleOrDefault();
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(SbAccountv s){
            db.SbAccountvs.Update(s);
            db.SaveChanges();
            return RedirectToAction("GetAllAcounts");
        }

        // Delete
        public ActionResult Delete(int id){ // here we do not pass accno as argument bcz compiler gets confused and its compulsion to pass argument named "id" only for delete to work
            var s = db.SbAccountvs.Where(x=>x.AccountNumber == id).Select(x=>x).SingleOrDefault();
            return View(s);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id){ // argument named "id" is must for delete to work
            var s = db.SbAccountvs.Where(x=>x.AccountNumber == id).Select(x=>x).SingleOrDefault();
            if(s != null){
                db.SbAccountvs.Remove(s);
            }
            db.SaveChanges();
            return RedirectToAction("GetAllAcounts");
        }
    }
}

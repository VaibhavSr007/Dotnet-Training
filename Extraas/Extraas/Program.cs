// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using EfcoreEx.Models;
using Microsoft.Identity.Client;

namespace EfcoreEx{

    class Program{
        
        private static Ace52024Context db = new Ace52024Context();
        public static void Main(){
            
            // complete CRUD operations on the data in DB
            // AddData();
            // DeleteData();
            // UpdateData();
            // SelectData();
            GetDataByName();
            
        }


        public static void AddData(){ // Add/ Create
            Student007 s = new Student007();

            Console.WriteLine("Ente the Students Name: ");
            s.Sname = Console.ReadLine();
            Console.WriteLine("Ente the Students Roll No: ");
            s.Sid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ente the Students Marks: ");
            s.Marks = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ente the Students DOB: ");
            s.Dob = DateOnly.Parse(Console.ReadLine());
            db.Add(s); // add the context to db
            db.SaveChanges(); //permanentaly add the student to db
        }


        public static void DeleteData(){ // Delete

            var s = db.Student007s.Where(x=>x.Sid == 110).Select(x=>x).SingleOrDefault();
            db.Remove(s);
            db.SaveChanges();
            
        }
        public static void SelectData(){ // Read
            
            Console.WriteLine();
            Console.WriteLine("Students and their data are: ");
            foreach(var i in db.Student007s){
                Console.WriteLine(i.Sid + " " + i.Sname + " " + i.Marks + " " + i.Dob);    
                
            }
        }

        public static void UpdateData(){ // update
            var s = db.Student007s.Where(x=>x.Sid == 0).Select(x=>x).SingleOrDefault();
            s.Marks = 170;
            db.Student007s.Update(s);
            db.SaveChanges();

            var s1 = (from i in db.Student007s where i.Sid == 2 select i).SingleOrDefault();
            s1.Sname = "Sai Anand";
            db.SaveChanges();
        }

        public static void GetDataByName(){
            Console.WriteLine("Enter the name of student for all details: ");
            string name = Console.ReadLine();
            var s = db.Student007s.Where(x=>x.Sname == name).Select(x=>x).SingleOrDefault();
            if(s != null){
                Console.WriteLine(s.Sid + " " + s.Sname + " " + s.Marks + " " + s.Dob); 
            }
            else{
                Console.WriteLine("No student named " + name + " in the Database");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using firstmvcprj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace firstmvcprj.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private Ace52024Context db = new Ace52024Context();
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        public IActionResult ShowEmpData(){
            
            Employee e = new Employee();
            e.Eid = 7;
            e.Ename = "Vaibhav";
            e.Salary = 2000000;
            
            return View(e);
        }

        public IActionResult GetAllEmployees(){
            
            List<Employee> employees = new List<Employee>();    
            Employee e1 = new Employee();
            e1.Eid = 7;
            e1.Ename = "Vaibhav";
            e1.Salary = 2000000;
            employees.Add(e1);

            Employee e2 = new Employee();
            e2.Eid = 9;
            e2.Ename = "Aayush";
            e2.Salary = 1000000;
            employees.Add(e2);

            Employee e3 = new Employee();
            e3.Eid = 18;
            e3.Ename = "Shriya";
            e3.Salary = 1500000;
            employees.Add(e3);
            
            return View(employees);
        }


        public IActionResult ShowAllEmployees(){
            
            List<Employee> employees = new List<Employee>();    
            Employee e1 = new Employee();
            e1.Eid = 7;
            e1.Ename = "Vaibhav";
            e1.Salary = 2000000;
            employees.Add(e1);

            Employee e2 = new Employee();
            e2.Eid = 9;
            e2.Ename = "Aayush";
            e2.Salary = 1000000;
            employees.Add(e2);

            Employee e3 = new Employee();
            e3.Eid = 18;
            e3.Ename = "Shriya";
            e3.Salary = 1500000;
            employees.Add(e3);
            
            return View(employees);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
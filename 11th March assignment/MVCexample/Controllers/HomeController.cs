using Microsoft.AspNetCore.Mvc;
using MVCexample.Models;
using System.Diagnostics;

namespace MVCexample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public string sampledemo1()
        {
            return "Ayush Agarwala";
        }
        public string sampledemo2(int age,string name)
        {
            return $"The name is {name} with age {age}";
        }
        public IActionResult sampledemo3()
        {
            int age = 21;
            string name = "Ayush Agarwala";
            ViewBag.name = name;
            ViewBag.age = age;
            ViewData["Message"] = "Welcome to ASP.NET core learning";
            ViewData["Year"] = DateTime.Now.Year;
            return View();
        }
        Employee emp = new Employee() { EmployeeId = 101, EmployeeName = "Ayush Agarwala", EmployeeSalary = 50000 };
        List<Employee> emplist = new List<Employee>()
        {
            new Employee() { EmployeeId = 101, EmployeeName = "Ayush Agarwala", EmployeeSalary = 50000,ImageUrl="/images/pic1.jpg" },
            new Employee() { EmployeeId = 102, EmployeeName = "Harsh Agarwala", EmployeeSalary = 50400,ImageUrl="/images/pic2.jpg" },
            new Employee() { EmployeeId = 103, EmployeeName = "John Doe", EmployeeSalary = 60000,ImageUrl="/images/pic3.jpg" },
            new Employee() { EmployeeId = 103, EmployeeName = "Jane Smith", EmployeeSalary = 55000,ImageUrl="/images/pic4.jpg" }
        };
        public IActionResult CollectionOfObjectPassing()
        {
            return View(emplist);
        }
        public IActionResult Display()
        {
            return View();
        }
        public IActionResult singleObjectPassing()
        {
            return View(emp);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

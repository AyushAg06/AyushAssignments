using CodeFirstEFinASP.net.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeFirstEFinASP.net.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EventContext _context;


        public HomeController(ILogger<HomeController> logger,EventContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Displayemp()
        {
            var employees=_context.employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Displayemp");
            }
            return View(employee);
        }
        public IActionResult Details(int id)
        {
            var employee= _context.employees.FirstOrDefault(x => x.Id == id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        public IActionResult Edit(int id)
        {
            var employee=_context.employees.Find(id);
            if (employee == null)
            {
                return BadRequest();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(int id,Employee employee)
        {
            if(id!=employee.Id)
            {
                return BadRequest();
            }
            else
            {
                _context.Update(employee);
                _context.SaveChanges();
                return RedirectToAction("Displayemp");
            }
            return View(employee);
        }
        public IActionResult Delete(int id)
        {
            var employee = _context.employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }


        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _context.employees.Find(id);
            if (employee != null)
            {
                _context.employees.Remove(employee);
                _context.SaveChanges();
            }
            return RedirectToAction("Displayemp");
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

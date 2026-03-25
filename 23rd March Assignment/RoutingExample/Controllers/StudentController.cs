using Microsoft.AspNetCore.Mvc;
using RoutingExample.Models;

namespace RoutingExample.Controllers
{
    public class StudentController : Controller
    {
        List<Student> studlist=new List<Student>()
        {
            new Student{Id=101,Name="Ayush",Class="class4"},
            new Student{Id=102,Name="Ravish",Class="class3"},
            new Student{Id=103,Name="Harsh",Class="class9"},
            new Student{Id=104,Name="Ravi",Class="class3"}
        };
        public IActionResult Index()
        {
            return View();
        }
        [Route("studs")]
        public IActionResult GetAllStudents()
        {
            return View(studlist);
        }
        [Route("studs/{id}")]
        public IActionResult GetStudent(int id)
        {
            var student=studlist.FirstOrDefault(x=>x.Id==id);
            return View(student);
        }
        [Route("fewcolumns")]
        public IActionResult fewcolumns()
        {
            var fewcolumns = studlist.Select(x => new Student { Class =x.Class,Name = x.Name, });
            return View(fewcolumns);
        }
    }
}

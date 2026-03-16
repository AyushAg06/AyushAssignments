using DbFirstEFinAsp.Models;
using DbFirstEFinAsp.Models.NorthWindViewModels;
using Microsoft.AspNetCore.Mvc;
namespace DbFirstEFinAsp.Controllers
{
    public class NorthWindController : Controller
    {
        public IActionResult SpainCustomer()
        {
            NorthWindContext context = new NorthWindContext();
            var spainCustomers = context.Customers.Where(x => x.Country == "Spain").Select(x => new SpainCustomerViewModel
            {
                Cid = x.CustomerId,
                Cname = x.ContactName,
                Comname = x.CompanyName
            }).ToList();

            return View(spainCustomers);
        }
        public IActionResult SearchCustomer(string ContactName)
        {
            NorthWindContext context = new NorthWindContext();
            var SearchCustomers= context.Customers.Where(x => x.ContactName == ContactName).Select(x => new SpainCustomerViewModel
            {
                Cid = x.CustomerId,
                Cname = x.ContactName,
                Comname = x.CompanyName
            }).ToList();
            return View(SearchCustomers);
        }
        [HttpGet]
        public IActionResult EditCustomer(string CustomerId)
        {
            NorthWindContext context = new NorthWindContext();
            var EditCustomers = context.Customers.Where(x => x.CustomerId==CustomerId).Select(x => new SpainCustomerViewModel
            {
                Cid = x.CustomerId,
                Cname = x.ContactName,
                Comname = x.CompanyName
            }).FirstOrDefault();

            return View(EditCustomers);
        }
        [HttpPost]
        public IActionResult EditCustomer(SpainCustomerViewModel model)
        {
            NorthWindContext context = new NorthWindContext();
            var Customer=context.Customers.FirstOrDefault(x=>x.CustomerId==model.Cid);
            if(Customer!=null)
            {
                Customer.CompanyName = model.Cname;
                Customer.CompanyName = model.Comname;
                context.SaveChanges();
            }
            return RedirectToAction("SpainCustomer");
        }
    }
}

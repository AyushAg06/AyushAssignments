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
        public IActionResult ProductsInCategory(string categoryName)
        {
            NorthWindContext cnt=new NorthWindContext();
            var ProductsInCategorys = cnt.Products.Where(x => x.Category.CategoryName == categoryName).
                Select(x=>new ProdCat
                {
                    prodname = x.ProductName,
                    catname=x.Category.CategoryName,
                }).ToList();
            return View(ProductsInCategorys);
        }
        public IActionResult OrderRange(string range)
        {
            NorthWindContext cnt=new NorthWindContext();
            var range1=Convert.ToInt16(range);
            var CustOrderCount = cnt.Customers
                .Where(x=>x.Orders.Count>range1).
                Select(x=>new Customer
                {
                    CustomerId=x.CustomerId,
                    ContactName=x.ContactName,
                });
            return View(CustOrderCount);
        }
        public IActionResult CustomerOrderDetails(string id)
        {
            NorthWindContext cnt = new NorthWindContext();

            var orders = cnt.Orders
                .Where(o => o.CustomerId == id)
                .Select(o => new Order
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    RequiredDate = o.RequiredDate,
                    ShippedDate = o.ShippedDate
                }).ToList();

            ViewBag.CustomerId = id;

            return View(orders);
        }
    }
}

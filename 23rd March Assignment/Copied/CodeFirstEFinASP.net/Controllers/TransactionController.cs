using CodeFirstEFinASP.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFinASP.net.Controllers
{
    public class TransactionController : Controller
    {
        private readonly EventContext _context;
        public TransactionController(EventContext context)
        {
            _context = context;
        }
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            //ModelState.Clear();
            //ModelState.Remove(nameof(customer.CustomerId));

            if(customer.CustomerName!=null)
            {

                _context.Customers.Add(customer);
                _context.SaveChanges();
                return Content("Customer added");
                //return RedirectToAction("CreateCustomer");
            }
            return View(customer);
        }
        public IActionResult CreateProduct(int? CustomerId=null)
        {
            var cid = CustomerId ?? 0;
            ViewBag.CustomerId = cid;
            ViewBag.CustomerList = new SelectList(_context.Customers, "CustomerId", "CustomerName", cid);
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            ModelState.Clear();
            ModelState.Remove(nameof(product.ProductId));

            if (ModelState.IsValid)
            {

                _context.Products.Add(product);
                _context.SaveChanges();
                //return Content("Product added");
                return RedirectToAction
                    ("CreateProduct", new { customerId = product.CustomerId });
            }
            // preserving values 
            ViewBag.customerId = product.CustomerId;
            ViewBag.CustomerList = new SelectList(_context.Customers,
               "CustomerID", "CustomerName", product.CustomerId);
            return View(product);
        }
        public IActionResult Summary(int customerId)
        {
            var customer = _context.Customers
                .Include(c => c.Products)
                .FirstOrDefault(c => c.CustomerId == customerId);

            if (customer == null || !customer.Products.Any())
            {
                return RedirectToAction("CreateProduct", new { customerId });
            }

            return View(customer);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

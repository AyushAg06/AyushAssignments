using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFdemo.Models
{
    internal class Product
    {
        public int Id { get; set; }//this will create an identity column in the database
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
    }
}

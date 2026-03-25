using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEFinASP.net.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName {  get; set; }

        [Display (Name="Who buys")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
       
        public Customer Customer { get; set; }
    }
}

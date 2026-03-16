using System.ComponentModel.DataAnnotations;

namespace DbFirstEFinAsp.Models.NorthWindViewModels
{
    public class SpainCustomerViewModel
    {
        [Key]
            public string Cid { get; set; }
            public string Cname { get; set; }
            public string Comname { get; set; }
        
    }
}

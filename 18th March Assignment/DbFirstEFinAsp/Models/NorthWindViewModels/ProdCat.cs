using System.ComponentModel.DataAnnotations;

namespace DbFirstEFinAsp.Models.NorthWindViewModels
{
    public class ProdCat
    {
        [Key]
        public string? prodname { set; get; }
        public string? catname { set; get; }
    }
}

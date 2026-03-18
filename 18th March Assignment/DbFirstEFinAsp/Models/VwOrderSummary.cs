using System;
using System.Collections.Generic;

namespace DbFirstEFinAsp.Models;

public partial class VwOrderSummary
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string CompanyName { get; set; } = null!;

    public decimal? TotalAmount { get; set; }
}

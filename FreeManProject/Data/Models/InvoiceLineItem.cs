using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class InvoiceLineItem
{
    public int LineItemId { get; set; }

    public int? InvoiceId { get; set; }

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? ItemType { get; set; }

    public int? ItemReferenceId { get; set; }

    public DateTime? CreatedAt { get; set; }
}

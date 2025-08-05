using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class invoice_line_item
{
    public int line_item_id { get; set; }

    public int? invoice_id { get; set; }

    public string? description { get; set; }

    public int? quantity { get; set; }

    public decimal? unit_price { get; set; }

    public decimal? total_price { get; set; }

    public string? item_type { get; set; }

    public int? item_reference_id { get; set; }

    public DateTime? created_at { get; set; }
}

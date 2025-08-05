using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class invoice
{
    public int invoice_id { get; set; }

    public int? member_id { get; set; }

    public string invoice_number { get; set; } = null!;

    public DateOnly? invoice_date { get; set; }

    public DateOnly? due_date { get; set; }

    public decimal? subtotal { get; set; }

    public decimal? discount_amount { get; set; }

    public decimal? total_amount { get; set; }

    public decimal? amount_paid { get; set; }

    public decimal? balance_due { get; set; }

    public string? invoice_status { get; set; }

    public string? payment_terms { get; set; }

    public string? notes { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }
}

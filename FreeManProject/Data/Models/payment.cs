using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class payment
{
    public int payment_id { get; set; }

    public int? member_id { get; set; }

    public string? payment_type { get; set; }

    public int? reference_id { get; set; }

    public decimal? amount { get; set; }

    public string? payment_method { get; set; }

    public DateTime? payment_date { get; set; }

    public DateOnly? due_date { get; set; }

    public string? payment_status { get; set; }

    public string? transaction_id { get; set; }

    public string? description { get; set; }

    public decimal? discount_applied { get; set; }

    public int? staff_id { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }
}

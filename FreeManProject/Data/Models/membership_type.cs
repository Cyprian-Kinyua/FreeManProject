using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class membership_type
{
    public int membership_type_id { get; set; }

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public int? duration_days { get; set; }

    public decimal? price { get; set; }

    public string? membership_type_status { get; set; }

    public DateOnly? created_at { get; set; }

    public DateOnly? updated_at { get; set; }
}

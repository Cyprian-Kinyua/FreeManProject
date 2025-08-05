using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class equipment
{
    public int equipment_id { get; set; }

    public string name { get; set; } = null!;

    public int equipment_category { get; set; }

    public string? brand { get; set; }

    public string? model { get; set; }

    public string? serial_number { get; set; }

    public DateOnly? purchase_date { get; set; }

    public decimal? purchase_price { get; set; }

    public DateOnly? warranty_expiry_date { get; set; }

    public string? location_area { get; set; }

    public string? equipment_status { get; set; }

    public DateOnly? last_maintenance_date { get; set; }

    public DateOnly? next_maintenance_due { get; set; }

    public string? usage_instructions { get; set; }

    public string? safety_notes { get; set; }

    public DateOnly? created_at { get; set; }

    public DateOnly? updated_at { get; set; }
}

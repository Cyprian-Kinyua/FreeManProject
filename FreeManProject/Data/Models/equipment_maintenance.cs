using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class equipment_maintenance
{
    public int maintenance_id { get; set; }

    public int? equipment_id { get; set; }

    public int? staff_id { get; set; }

    public DateOnly maintenance_date { get; set; }

    public string maintenance_type { get; set; } = null!;

    public string? description { get; set; }

    public decimal? cost { get; set; }

    public string? parts_replaced { get; set; }

    public DateOnly? next_maintenance_date { get; set; }

    public string performed_by { get; set; } = null!;

    public string? vendor_name { get; set; }

    public string? status { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }
}

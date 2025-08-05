using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class facility
{
    public int facility_id { get; set; }

    public string name { get; set; } = null!;

    public int facility_type_id { get; set; }

    public int? capacity { get; set; }

    public decimal? area_square_feet { get; set; }

    public string? special_equipment_required { get; set; }

    public bool? booking_required { get; set; }

    public decimal? hourly_rate { get; set; }

    public TimeOnly? availability_hours_start { get; set; }

    public TimeOnly? availability_hours_end { get; set; }

    public string? status { get; set; }

    public DateOnly? created_at { get; set; }

    public DateOnly? updated_at { get; set; }
}

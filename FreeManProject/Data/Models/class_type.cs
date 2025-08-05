using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class class_type
{
    public int class_type_id { get; set; }

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public string? difficulty_level { get; set; }

    public int? duration_minutes { get; set; }

    public int? max_participants { get; set; }

    public string? equipment_required { get; set; }

    public int? calories_burned_estimate { get; set; }

    public decimal? additional_fee { get; set; }

    public string? class_type_status { get; set; }

    public DateOnly? created_at { get; set; }

    public DateOnly? updated_at { get; set; }
}

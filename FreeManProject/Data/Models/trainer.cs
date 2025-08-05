using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class trainer
{
    public int trainer_id { get; set; }

    public string staff_regno { get; set; } = null!;

    public string specialization { get; set; } = null!;

    public int? experience_years { get; set; }

    public double? hourly_rate { get; set; }

    public int? class_weekly_frequency { get; set; }

    public string? bio { get; set; }

    public int? total_sessions_conducted { get; set; }

    public int? sessions_for_month { get; set; }

    public string? trainer_status { get; set; }

    public DateOnly? created_at { get; set; }

    public DateOnly? updated_at { get; set; }
}

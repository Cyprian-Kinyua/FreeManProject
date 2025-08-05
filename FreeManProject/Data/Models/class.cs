using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class class
{
    public int class_id { get; set; }

    public int? class_type_id { get; set; }

    public int? trainer_id { get; set; }

    public int? facility_id { get; set; }

    public DateOnly class_date { get; set; }

    public TimeOnly start_time { get; set; }

    public TimeOnly end_time { get; set; }

    public int? max_participants { get; set; }

    public int? current_bookings { get; set; }

    public int? waitlist_count { get; set; }

    public string? status { get; set; }

    public string? cancellation_reason { get; set; }

    public string? special_notes { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }
}

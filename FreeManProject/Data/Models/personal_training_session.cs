using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class personal_training_session
{
    public int session_id { get; set; }

    public int? member_id { get; set; }

    public int? trainer_id { get; set; }

    public int? facility_id { get; set; }

    public DateOnly session_date { get; set; }

    public TimeOnly start_time { get; set; }

    public TimeOnly end_time { get; set; }

    public string? session_type { get; set; }

    public string? goals { get; set; }

    public string? personal_training_session_status { get; set; }

    public string? attendance_status { get; set; }

    public string? trainer_notes { get; set; }

    public string? member_feedback { get; set; }

    public sbyte? rating { get; set; }

    public decimal? amount_charged { get; set; }

    public string? payment_status { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }
}

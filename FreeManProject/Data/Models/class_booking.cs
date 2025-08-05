using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class class_booking
{
    public int booking_id { get; set; }

    public int? class_id { get; set; }

    public int? member_id { get; set; }

    public DateTime booking_date { get; set; }

    public string? booking_status { get; set; }

    public string? payment_status { get; set; }

    public decimal? amount_paid { get; set; }

    public DateTime? cancellation_date { get; set; }

    public bool? attendance_marked { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }
}

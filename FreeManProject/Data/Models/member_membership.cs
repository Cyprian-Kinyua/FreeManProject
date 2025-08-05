using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class member_membership
{
    public int member_membership_id { get; set; }

    public string member_regno { get; set; } = null!;

    public int membership_type_id { get; set; }

    public DateOnly? start_date { get; set; }

    public DateOnly? end_date { get; set; }

    public string? member_membership_status { get; set; }

    public bool? auto_renewal { get; set; }

    public string? payment_method { get; set; }

    public DateOnly? created_at { get; set; }

    public DateOnly? updated_at { get; set; }
}

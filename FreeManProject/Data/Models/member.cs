using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class member
{
    public int member_id { get; set; }

    public string member_regno { get; set; } = null!;

    public string first_name { get; set; } = null!;

    public string? last_name { get; set; }

    public string? email { get; set; }

    public string phone_number { get; set; } = null!;

    public DateOnly? date_of_birth { get; set; }

    public string? gender { get; set; }

    public int postal_address { get; set; }

    public string? city { get; set; }

    public int? postal_code { get; set; }

    public string emergency_contact_name { get; set; } = null!;

    public string emergency_contact_phone { get; set; } = null!;

    public DateOnly? registration_date { get; set; }

    public string? member_status { get; set; }

    public string? profile_photo_url { get; set; }

    public DateOnly? created_at { get; set; }

    public DateOnly? updated_at { get; set; }
}

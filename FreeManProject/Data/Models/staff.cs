using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string StaffRegno { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public int PostalAddress { get; set; }

    public string? City { get; set; }

    public int? PostalCode { get; set; }

    public string EmergencyContactName { get; set; } = null!;

    public string EmergencyContactPhone { get; set; } = null!;

    public DateOnly? HireDate { get; set; }

    public string? Position { get; set; }

    public string? Department { get; set; }

    public decimal? Salary { get; set; }

    public string? StaffStatus { get; set; }

    public string? ProfilePhotoUrl { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly? UpdatedAt { get; set; }
}

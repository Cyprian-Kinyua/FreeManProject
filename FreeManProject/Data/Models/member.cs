using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string MemberRegno { get; set; } = null!;

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

    public DateOnly? RegistrationDate { get; set; }

    public string? MemberStatus { get; set; }

    public string? ProfilePhotoUrl { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly? UpdatedAt { get; set; }
}

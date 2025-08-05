using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class MemberMembership
{
    public int MemberMembershipId { get; set; }

    public string MemberRegno { get; set; } = null!;

    public int MembershipTypeId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? MemberMembershipStatus { get; set; }

    public bool? AutoRenewal { get; set; }

    public string? PaymentMethod { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly? UpdatedAt { get; set; }
}

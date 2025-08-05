using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class MembershipType
{
    public int MembershipTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? DurationDays { get; set; }

    public decimal? Price { get; set; }

    public string? MembershipTypeStatus { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly? UpdatedAt { get; set; }
}

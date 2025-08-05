using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class Facility
{
    public int FacilityId { get; set; }

    public string Name { get; set; } = null!;

    public int FacilityTypeId { get; set; }

    public int? Capacity { get; set; }

    public decimal? AreaSquareFeet { get; set; }

    public string? SpecialEquipmentRequired { get; set; }

    public bool? BookingRequired { get; set; }

    public decimal? HourlyRate { get; set; }

    public TimeOnly? AvailabilityHoursStart { get; set; }

    public TimeOnly? AvailabilityHoursEnd { get; set; }

    public string? Status { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly? UpdatedAt { get; set; }
}

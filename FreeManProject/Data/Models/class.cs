using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public int? ClassTypeId { get; set; }

    public int? TrainerId { get; set; }

    public int? FacilityId { get; set; }

    public DateOnly ClassDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int? MaxParticipants { get; set; }

    public int? CurrentBookings { get; set; }

    public int? WaitlistCount { get; set; }

    public string? Status { get; set; }

    public string? CancellationReason { get; set; }

    public string? SpecialNotes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

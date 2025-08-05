using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class PersonalTrainingSession
{
    public int SessionId { get; set; }

    public int? MemberId { get; set; }

    public int? TrainerId { get; set; }

    public int? FacilityId { get; set; }

    public DateOnly SessionDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string? SessionType { get; set; }

    public string? Goals { get; set; }

    public string? PersonalTrainingSessionStatus { get; set; }

    public string? AttendanceStatus { get; set; }

    public string? TrainerNotes { get; set; }

    public string? MemberFeedback { get; set; }

    public sbyte? Rating { get; set; }

    public decimal? AmountCharged { get; set; }

    public string? PaymentStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

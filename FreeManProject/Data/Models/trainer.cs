using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class Trainer
{
    public int TrainerId { get; set; }

    public string StaffRegno { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public int? ExperienceYears { get; set; }

    public double? HourlyRate { get; set; }

    public int? ClassWeeklyFrequency { get; set; }

    public string? Bio { get; set; }

    public int? TotalSessionsConducted { get; set; }

    public int? SessionsForMonth { get; set; }

    public string? TrainerStatus { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly? UpdatedAt { get; set; }
}

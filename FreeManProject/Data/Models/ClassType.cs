using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class ClassType
{
    public int ClassTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? DifficultyLevel { get; set; }

    public int? DurationMinutes { get; set; }

    public int? MaxParticipants { get; set; }

    public string? EquipmentRequired { get; set; }

    public int? CaloriesBurnedEstimate { get; set; }

    public decimal? AdditionalFee { get; set; }

    public string? ClassTypeStatus { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly? UpdatedAt { get; set; }
}

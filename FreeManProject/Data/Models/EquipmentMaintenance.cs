using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class EquipmentMaintenance
{
    public int MaintenanceId { get; set; }

    public int? EquipmentId { get; set; }

    public int? StaffId { get; set; }

    public DateOnly MaintenanceDate { get; set; }

    public string MaintenanceType { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Cost { get; set; }

    public string? PartsReplaced { get; set; }

    public DateOnly? NextMaintenanceDate { get; set; }

    public string PerformedBy { get; set; } = null!;

    public string? VendorName { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

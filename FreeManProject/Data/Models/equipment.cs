using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class Equipment
{
    public int EquipmentId { get; set; }

    public string Name { get; set; } = null!;

    public int EquipmentCategory { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public string? SerialNumber { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public decimal? PurchasePrice { get; set; }

    public DateOnly? WarrantyExpiryDate { get; set; }

    public string? LocationArea { get; set; }

    public string? EquipmentStatus { get; set; }

    public DateOnly? LastMaintenanceDate { get; set; }

    public DateOnly? NextMaintenanceDue { get; set; }

    public string? UsageInstructions { get; set; }

    public string? SafetyNotes { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly? UpdatedAt { get; set; }
}

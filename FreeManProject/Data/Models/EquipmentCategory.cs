using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class EquipmentCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;
}

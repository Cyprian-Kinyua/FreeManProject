using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class FacilityType
{
    public int FacilityTypeId { get; set; }

    public string FacilityName { get; set; } = null!;
}

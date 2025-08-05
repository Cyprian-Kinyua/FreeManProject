using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class facility_type
{
    public int facility_type_id { get; set; }

    public string facility_name { get; set; } = null!;
}

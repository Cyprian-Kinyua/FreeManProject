using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class equipment_category
{
    public int category_id { get; set; }

    public string category_name { get; set; } = null!;
}

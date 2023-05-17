using System;
using System.Collections.Generic;

namespace Unit_7_Producing_Rest_API_Lab.Models;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}

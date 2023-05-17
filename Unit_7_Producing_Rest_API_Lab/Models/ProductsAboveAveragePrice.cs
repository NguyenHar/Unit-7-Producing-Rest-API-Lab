using System;
using System.Collections.Generic;

namespace Unit_7_Producing_Rest_API_Lab.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}

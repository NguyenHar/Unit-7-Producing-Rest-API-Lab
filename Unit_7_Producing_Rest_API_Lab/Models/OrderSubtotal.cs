using System;
using System.Collections.Generic;

namespace Unit_7_Producing_Rest_API_Lab.Models;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}

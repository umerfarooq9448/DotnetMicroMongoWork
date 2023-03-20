using System;
using System.Collections.Generic;

namespace Customer_Api.Models;

public partial class CustomerTable
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public int? CustomerAge { get; set; }
}

using System;
using System.Collections.Generic;

namespace Customer_Api.Models;

public partial class ProductsTable
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductDescription { get; set; }

    public int? ProductPrice { get; set; }
}

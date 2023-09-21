using System;
using System.Collections.Generic;

namespace Summit.Models.Models;

public partial class CustomerFna
{
    public string CustFnaId { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public int FnaId { get; set; }

    public string Input { get; set; } = null!;

    public string Output { get; set; } = null!;

    public int? Score { get; set; }

    public bool? Status { get; set; }

    public DateTime DateAdded { get; set; }

    public DateTime? LastUpdated { get; set; }

    public string? UpdatedBy { get; set; }

    public string? Addedby { get; set; }
}

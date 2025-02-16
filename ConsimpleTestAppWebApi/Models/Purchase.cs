using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestAppWebApi.Models;

public partial class Purchase
{
    [Key]
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public double TotalCost { get; set; }

    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Purchases")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Purchase")]
    public virtual ICollection<PurchaseProduct> PurchaseProducts { get; set; } = new List<PurchaseProduct>();
}

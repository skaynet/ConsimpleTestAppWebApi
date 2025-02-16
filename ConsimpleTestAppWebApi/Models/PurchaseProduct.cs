using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestAppWebApi.Models;

public partial class PurchaseProduct
{
    [Key]
    public int Id { get; set; }

    public int PurchaseId { get; set; }

    public int ProductId { get; set; }

    public int Amount { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("PurchaseProducts")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("PurchaseId")]
    [InverseProperty("PurchaseProducts")]
    public virtual Purchase Purchase { get; set; } = null!;
}

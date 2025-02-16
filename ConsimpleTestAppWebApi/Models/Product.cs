using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestAppWebApi.Models;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    [StringLength(256)]
    public string Name { get; set; } = null!;

    public int СategoryId { get; set; }

    [StringLength(128)]
    public string Article { get; set; } = null!;

    public double Price { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<PurchaseProduct> PurchaseProducts { get; set; } = new List<PurchaseProduct>();

    [ForeignKey("СategoryId")]
    [InverseProperty("Products")]
    public virtual Сategory Сategory { get; set; } = null!;
}

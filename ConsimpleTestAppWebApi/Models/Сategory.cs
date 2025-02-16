using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestAppWebApi.Models;

[Table("Сategory")]
public partial class Сategory
{
    [Key]
    public int Id { get; set; }

    [StringLength(128)]
    public string Name { get; set; } = null!;

    [InverseProperty("Сategory")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestAppWebApi.Models;

[Table("Customer")]
[Index("FullName", Name = "UQ_Customer_FullName", IsUnique = true)]
public partial class Customer
{
    [Key]
    public int Id { get; set; }

    [StringLength(128)]
    public string FullName { get; set; } = null!;

    public DateOnly DateBirth { get; set; }

    public DateOnly DateRegistration { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}

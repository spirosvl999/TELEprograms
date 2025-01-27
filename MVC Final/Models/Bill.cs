using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Final.Models;

public partial class Bill
{
    [Key]
    [Column("Bill_id")]
    public int BillId { get; set; }

    [Column("phoneNumber")]
    [StringLength(15)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [Column(TypeName = "decimal(7, 2)")]
    public decimal? Costs { get; set; }

    [InverseProperty("Bill")]
    public virtual BillsCall? BillsCall { get; set; }

    [ForeignKey("PhoneNumber")]
    [InverseProperty("Bills")]
    public virtual Phone PhoneNumberNavigation { get; set; } = null!;
}

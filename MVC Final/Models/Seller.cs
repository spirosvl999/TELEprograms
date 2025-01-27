using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Final.Models;

[Table("sellers")]
public partial class Seller
{
    [Key]
    [Column("Seller_id")]
    public int SellerId { get; set; }

    [Column("User_id")]
    public int UserId { get; set; }
}

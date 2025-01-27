using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Final.Models;

[Table("admin")]
public partial class Admin
{
    [Key]
    [Column("Admin_id")]
    public int AdminId { get; set; }

    [Column("User_id")]
    public int UserId { get; set; }
}

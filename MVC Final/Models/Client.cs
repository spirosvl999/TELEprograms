using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Final.Models;

[Table("clients")]
public partial class Client
{
    [Key]
    [Column("Client_id")]
    public int ClientId { get; set; }

    [Column("AFM")]
    [StringLength(50)]
    [Unicode(false)]
    public string Afm { get; set; } = null!;

    [Column("phoneNumber")]
    [StringLength(15)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [Column("User_id")]
    public int? UserId { get; set; }

    [ForeignKey("PhoneNumber")]
    [InverseProperty("Clients")]
    public virtual Phone PhoneNumberNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Final.Models;

public partial class Call
{
    [Key]
    [Column("Call_id")]
    public int CallId { get; set; }

    [Column(TypeName = "text")]
    public string Description { get; set; } = null!;

    [InverseProperty("Call")]
    public virtual ICollection<BillsCall> BillsCalls { get; set; } = new List<BillsCall>();
}

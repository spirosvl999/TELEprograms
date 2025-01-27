using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Final.Models;

public partial class BillsCall
{
    [Key]
    [Column("Bill_id")]
    public int BillId { get; set; }

    [Column("Call_id")]
    public int CallId { get; set; }

    [ForeignKey("BillId")]
    [InverseProperty("BillsCall")]
    public virtual Bill Bill { get; set; } = null!;

    [ForeignKey("CallId")]
    [InverseProperty("BillsCalls")]
    public virtual Call Call { get; set; } = null!;
}

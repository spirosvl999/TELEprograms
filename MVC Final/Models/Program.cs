using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Final.Models;

[Table("programs")]
public partial class Program
{
    [Key]
    [Column("programName")]
    [StringLength(50)]
    [Unicode(false)]
    public string ProgramName { get; set; } = null!;

    [Column("benfits", TypeName = "text")]
    public string? Benfits { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Charge { get; set; }

    [InverseProperty("ProgramNameNavigation")]
    public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();
}

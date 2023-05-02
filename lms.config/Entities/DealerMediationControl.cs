using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lms.config.Entities;

[Table("dealer_mediation_controls")]
public partial class DealerMediationControl
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("dealer_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DealerId { get; set; }

    [Column("pushed_count")]
    public int? PushedCount { get; set; }

    [Column("max_count")]
    public int? MaxCount { get; set; }

    [Column("created_on", TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lms.config.Entities;

[Table("finance_push_logs")]
public partial class FinancePushLog
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("lead_id")]
    public long LeadId { get; set; }

    [Column("finance_partner")]
    [StringLength(100)]
    [Unicode(false)]
    public string? FinancePartner { get; set; }

    [Column("response")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Response { get; set; }

    [Column("status")]
    public bool Status { get; set; }

    [Column("created_on", TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    [ForeignKey("LeadId")]
    [InverseProperty("FinancePushLogs")]
    public virtual Lead Lead { get; set; } = null!;
}

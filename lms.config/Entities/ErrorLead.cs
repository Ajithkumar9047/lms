using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lms.config.Entities;

[Table("error_leads")]
public partial class ErrorLead
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("lead_log_id")]
    public long LeadLogId { get; set; }

    [Column("error_description")]
    [Unicode(false)]
    public string? ErrorDescription { get; set; }

    [ForeignKey("LeadLogId")]
    [InverseProperty("ErrorLeads")]
    public virtual LeadLog LeadLog { get; set; } = null!;
}

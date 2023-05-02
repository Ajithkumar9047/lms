using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lms.config.Entities;

[Table("lead_logs")]
public partial class LeadLog
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("lead_source")]
    [StringLength(100)]
    [Unicode(false)]
    public string LeadSource { get; set; } = null!;

    [Column("request")]
    [Unicode(false)]
    public string Request { get; set; } = null!;

    [Column("created_on", TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    [Column("processed")]
    public bool Processed { get; set; }

    [Column("error")]
    public bool? Error { get; set; }

    [InverseProperty("LeadLog")]
    public virtual ICollection<ErrorLead> ErrorLeads { get; } = new List<ErrorLead>();

    [InverseProperty("LeadLog")]
    public virtual ICollection<Lead> Leads { get; } = new List<Lead>();
}

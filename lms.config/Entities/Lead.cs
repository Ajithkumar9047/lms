using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lms.config.Entities;

[Table("leads")]
public partial class Lead
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("lead_log_id")]
    public long LeadLogId { get; set; }

    [Column("dealer_id")]
    [StringLength(100)]
    [Unicode(false)]
    public string? DealerId { get; set; }

    [Column("part_id")]
    [StringLength(100)]
    [Unicode(false)]
    public string? PartId { get; set; }

    [Column("model_id")]
    [StringLength(100)]
    [Unicode(false)]
    public string? ModelId { get; set; }

    [Column("is_ems_dealer")]
    public bool IsEmsDealer { get; set; }

    [Column("is_finance")]
    public bool IsFinance { get; set; }

    [Column("processed")]
    public bool Processed { get; set; }

    [Column("agency_code")]
    [StringLength(500)]
    [Unicode(false)]
    public string? AgencyCode { get; set; }

    [InverseProperty("Lead")]
    public virtual ICollection<ClassifiedLead> ClassifiedLeads { get; } = new List<ClassifiedLead>();

    [InverseProperty("Lead")]
    public virtual ICollection<CrmPushLog> CrmPushLogs { get; } = new List<CrmPushLog>();

    [InverseProperty("Lead")]
    public virtual ICollection<DmsPushLog> DmsPushLogs { get; } = new List<DmsPushLog>();

    [InverseProperty("Lead")]
    public virtual ICollection<EmsPushLog> EmsPushLogs { get; } = new List<EmsPushLog>();

    [InverseProperty("Lead")]
    public virtual ICollection<FinancePushLog> FinancePushLogs { get; } = new List<FinancePushLog>();

    [ForeignKey("LeadLogId")]
    [InverseProperty("Leads")]
    public virtual LeadLog LeadLog { get; set; } = null!;
}

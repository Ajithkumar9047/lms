using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lms.config.Entities;

[Table("classified_leads")]
public partial class ClassifiedLead
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("lead_id")]
    public long LeadId { get; set; }

    [Column("probability")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Probability { get; set; }

    [Column("lead_type")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LeadType { get; set; }

    [Column("created_on", TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    [ForeignKey("LeadId")]
    [InverseProperty("ClassifiedLeads")]
    public virtual Lead Lead { get; set; } = null!;
}

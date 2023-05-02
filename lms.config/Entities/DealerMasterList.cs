using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lms.config.Entities;

[Keyless]
[Table("DealerMasterList")]
public partial class DealerMasterList
{
    [Column("dealer_code")]
    public double? DealerCode { get; set; }

    [Column("branch_id")]
    public double? BranchId { get; set; }

    [Column("dealer_name")]
    [StringLength(255)]
    public string? DealerName { get; set; }

    [Column("dealer_spoc_name")]
    [StringLength(255)]
    public string? DealerSpocName { get; set; }

    [Column("dealer_new_spoc_numbers")]
    public double? DealerNewSpocNumbers { get; set; }

    [Column("dealer_alternate_mobile_no")]
    [StringLength(255)]
    public string? DealerAlternateMobileNo { get; set; }

    [Column("dealer_emailid")]
    [StringLength(255)]
    public string? DealerEmailid { get; set; }

    [Column("dealer_alternate_emailid")]
    [StringLength(255)]
    public string? DealerAlternateEmailid { get; set; }

    [Column("dealer_address")]
    [StringLength(255)]
    public string? DealerAddress { get; set; }

    [Column("dealer_territory")]
    [StringLength(255)]
    public string? DealerTerritory { get; set; }

    [Column("dealer_area_2")]
    [StringLength(255)]
    public string? DealerArea2 { get; set; }

    [Column("dealer_town")]
    [StringLength(255)]
    public string? DealerTown { get; set; }

    [Column("dealer_pincode")]
    public double? DealerPincode { get; set; }

    [Column("dealer_state")]
    [StringLength(255)]
    public string? DealerState { get; set; }

    [Column("dealer_zone")]
    [StringLength(255)]
    public string? DealerZone { get; set; }

    [Column("dealer_area")]
    [StringLength(255)]
    public string? DealerArea { get; set; }

    [Column("dealer_tm_name")]
    [StringLength(255)]
    public string? DealerTmName { get; set; }

    [Column("dealer_tm_email")]
    [StringLength(255)]
    public string? DealerTmEmail { get; set; }

    [Column("dealer_am_name")]
    [StringLength(255)]
    public string? DealerAmName { get; set; }

    [Column("dealer_am_email")]
    [StringLength(255)]
    public string? DealerAmEmail { get; set; }

    [Column("dealer_ism_name")]
    [StringLength(255)]
    public string? DealerIsmName { get; set; }

    [Column("dealer_ism_email")]
    [StringLength(255)]
    public string? DealerIsmEmail { get; set; }

    [Column("dealer_nsm_name")]
    [StringLength(255)]
    public string? DealerNsmName { get; set; }

    [Column("dealer_nsm_email")]
    [StringLength(255)]
    public string? DealerNsmEmail { get; set; }

    [Column("dealer_zonal_planner_name")]
    [StringLength(255)]
    public string? DealerZonalPlannerName { get; set; }

    [Column("dealer_zonal_planner_email")]
    [StringLength(255)]
    public string? DealerZonalPlannerEmail { get; set; }

    [Column("dealer_lead_city")]
    [StringLength(255)]
    public string? DealerLeadCity { get; set; }

    [Column("dealer_type")]
    [StringLength(255)]
    public string? DealerType { get; set; }

    [Column("threshold_count")]
    public double? ThresholdCount { get; set; }
}

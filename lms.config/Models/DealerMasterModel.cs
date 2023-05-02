using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lms.config.Models
{
	public class DealerMasterModel
	{
        public double? DealerCode { get; set; }

        public double? BranchId { get; set; }

        public string? DealerName { get; set; }

        public string? DealerSpocName { get; set; }

        public double? DealerNewSpocNumbers { get; set; }

        public string? DealerAlternateMobileNo { get; set; }

        public string? DealerEmailid { get; set; }

        public string? DealerAlternateEmailid { get; set; }

        public string? DealerAddress { get; set; }

        public string? DealerTerritory { get; set; }

        public string? DealerArea2 { get; set; }

        public string? DealerTown { get; set; }

        public double? DealerPincode { get; set; }

        public string? DealerState { get; set; }

        public string? DealerZone { get; set; }

        public string? DealerArea { get; set; }

        public string? DealerTmName { get; set; }

        public string? DealerTmEmail { get; set; }

        public string? DealerAmName { get; set; }

        public string? DealerAmEmail { get; set; }

        public string? DealerIsmName { get; set; }

        public string? DealerIsmEmail { get; set; }

        public string? DealerNsmName { get; set; }

        public string? DealerNsmEmail { get; set; }

        public string? DealerZonalPlannerName { get; set; }

        public string? DealerZonalPlannerEmail { get; set; }

        public string? DealerLeadCity { get; set; }

        public string? DealerType { get; set; }

        public double? ThresholdCount { get; set; }
    }
}


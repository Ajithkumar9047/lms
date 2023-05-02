using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lms.config.Models
{
	public class LeadModel
	{
        public long Id { get; set; }

        public long LeadLogId { get; set; }

        public string? DealerId { get; set; }

        public string? PartId { get; set; }

        public string? ModelId { get; set; }

        public bool IsEmsDealer { get; set; }

        public bool IsFinance { get; set; }

        public bool Processed { get; set; }

        public string? AgencyCode { get; set; }

        public LeadLogModel LeadLog { get; set; }
    }
}


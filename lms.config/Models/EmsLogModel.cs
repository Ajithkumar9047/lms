using System;
using lms.config.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lms.config.Models
{
	public class EmsLogModel
	{
        public long Id { get; set; }

        public long LeadId { get; set; }

        public string? InternetEnquiryId { get; set; }

        public string? Payload { get; set; }

        public string? Response { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}


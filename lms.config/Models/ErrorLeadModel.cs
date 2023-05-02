using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lms.config.Models
{
	public class ErrorLeadModel
	{
        public long Id { get; set; }

        public long LeadLogId { get; set; }

        public string? ErrorDescription { get; set; }

    }
}


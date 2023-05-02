using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lms.config.Models
{
	public class LeadLogModel
	{

        public string LeadSource { get; set; } = null!;

        public string Request { get; set; } = null!;

        public bool Processed { get; set; }

        public bool Error { get; set; }
    }
}


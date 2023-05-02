using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace lms.config.Models
{
	public class UpdateEmsModel
	{
        public long Id { get; set; }

        public string? Response { get; set; }

        public bool Status { get; set; }
    }
}


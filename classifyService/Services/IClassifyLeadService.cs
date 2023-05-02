using System;
using lms.config.Models;

namespace classifyService.Services
{
	public interface IClassifyLeadService
	{
		Task ClassifyLead(LeadRequestModel leadRequestModel, long lead_id);
	}
}


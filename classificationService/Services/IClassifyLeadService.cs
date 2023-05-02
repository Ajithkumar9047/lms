using System;
using lms.config.Models;

namespace classificationService.Services
{
	public interface IClassifyLeadService
	{
		Task ClassifyLead(LeadRequestModel leadRequestModel);
	}
}


using System;
using lms.config.Models;

namespace persistLeadService.Services
{
	public interface ILeadService
	{
		Task LeadService(LeadConsumeModel leadDispatchModel);
	}
}


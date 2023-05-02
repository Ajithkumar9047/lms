using System;
using lms.config.Models;

namespace persistLeadService.Repository
{
	public interface ILeadRepository
	{
		Task<long> CreateLead(LeadModel leadModel);
	}
}


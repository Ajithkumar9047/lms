using System;
using lms.config.Models;

namespace emsService.Services
{
	public interface IEmsService
	{
		Task<EmsResponseModel> PushEmsLeads(LeadRequestModel leadRequestModel, long lead_id);
	}
}


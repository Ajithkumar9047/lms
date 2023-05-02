using System;
using lms.config.Models;

namespace leadReceiptService.Services
{
	public interface ILeadLogService
	{
		Task<ServerResponse<long>> ProcessLead(LeadRequestModel leadRequestModel);
	}
}


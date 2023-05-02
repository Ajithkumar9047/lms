using System;
using lms.config.Models;

namespace leadReceiptService.Services
{
	public interface IProcessValidLeadService
	{
        Task<long> ProcessValidLead(LeadRequestModel leadRequestModel);

    }
}


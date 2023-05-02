using System;
using lms.config.Models;

namespace leadReceiptService.Repository
{
	public interface ILeadLogRepository
	{
		Task<long> CreateLeadLog(LeadLogModel leadLogModel);
        Task<long> CreateErrorLead(List<ErrorLeadModel> errorLeadModels);
    }
}


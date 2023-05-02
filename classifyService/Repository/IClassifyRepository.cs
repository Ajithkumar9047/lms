using System;
using lms.config.Models;

namespace classifyService.Repository
{
	public interface IClassifyRepository
	{
		Task<DealerMasterModel> GetDealer(int dealerId);
		Task InsertLeadType(LeadTypeResponseModel leadTypeResponseModel, long lead_id);
	}
}


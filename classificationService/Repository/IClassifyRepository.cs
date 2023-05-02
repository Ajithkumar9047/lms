using System;
using lms.config.Models;

namespace classificationService.Repository
{
	public interface IClassifyRepository
	{
		Task<DealerMasterModel> GetDealer(int dealerId);
	}
}


using System;
using lms.config.Models;

namespace emsService.Repository
{
	public interface IEmsRepository
	{
		Task<long> PushEmsLog(EmsLogModel emsLogModel);
		Task<long> UpdateEmsLog(UpdateEmsModel updateEmsModel);

    }
}


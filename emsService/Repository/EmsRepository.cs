using System;
using System.Reflection;
using AutoMapper;
using lms.config.Entities;
using lms.config.LMSContext;
using lms.config.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace emsService.Repository
{
	public class EmsRepository: IEmsRepository
	{
        readonly LMSDbContext lmsDbContext;
        readonly IMapper mapper;

        public EmsRepository(LMSDbContext lmsDbContext, IMapper mapper)
		{
            this.lmsDbContext = lmsDbContext;
            this.mapper = mapper;
		}

        public async Task<long> PushEmsLog(EmsLogModel emsLogModel)
        {
            var emsData = mapper.Map<EmsLogModel, EmsPushLog>(emsLogModel);

            await lmsDbContext.EmsPushLogs.AddAsync(emsData);

            await lmsDbContext.SaveChangesAsync();

            return emsData.Id;
        }

        public async Task<long> UpdateEmsLog(UpdateEmsModel updateEmsModel)
        {

            var emsLog = await lmsDbContext.EmsPushLogs.FindAsync(updateEmsModel.Id);

            var emsUpdate = mapper.Map<UpdateEmsModel, EmsPushLog>(updateEmsModel, emsLog);

            lmsDbContext.EmsPushLogs.Update(emsUpdate);

            await lmsDbContext.SaveChangesAsync();

            return emsLog.Id;
            

        }
    }
}


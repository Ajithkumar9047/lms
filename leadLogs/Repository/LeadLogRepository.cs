using System;
using lms.config.Models;
using AutoMapper;
using lms.config.Entities;

using lms.config.LMSContext;

namespace leadReceiptService.Repository
{
	public class LeadLogRepository: ILeadLogRepository
	{
        readonly LMSDbContext leadDbContext;
        readonly IMapper mapper;

        public LeadLogRepository(LMSDbContext leadDbContext, IMapper mapper)
		{
            this.leadDbContext = leadDbContext;
            this.mapper = mapper;
		}

        public async Task<long> CreateErrorLead(List<ErrorLeadModel> errorLeadModel)
        {
            var errorLead = mapper.Map<List<ErrorLeadModel>, List<ErrorLead>>(errorLeadModel);

            await leadDbContext.ErrorLeads.AddRangeAsync(errorLead);

            return await leadDbContext.SaveChangesAsync();
        }

        public async Task<long> CreateLeadLog(LeadLogModel leadLogModel)
        {
            var leadLog = mapper.Map<LeadLogModel, LeadLog>(leadLogModel);

            await leadDbContext.LeadLogs.AddAsync(leadLog);

            await leadDbContext.SaveChangesAsync();

            return leadLog.Id;
        }
    }
}


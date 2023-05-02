using System;
using AutoMapper;
using lms.config.Entities;
using lms.config.Models;

using lms.config.LMSContext;

namespace persistLeadService.Repository
{
	public class LeadRepository: ILeadRepository
	{
        readonly LMSDbContext lmsDbContext;
        readonly IMapper mapper;

        public LeadRepository(LMSDbContext lmsDbContext, IMapper mapper)
		{
            this.lmsDbContext = lmsDbContext;
            this.mapper = mapper;
		}

        public async Task<long> CreateLead(LeadModel leadModel)
        {
            var lead = mapper.Map<LeadModel, Lead>(leadModel);

            await lmsDbContext.Leads.AddAsync(lead);

            await lmsDbContext.SaveChangesAsync();

            return lead.Id;
        }
    }
}


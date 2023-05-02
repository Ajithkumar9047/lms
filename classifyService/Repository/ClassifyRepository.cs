using System;
using AutoMapper;
using System.Reflection;
using lms.config.LMSContext;
using Microsoft.EntityFrameworkCore;
using lms.config.Entities;
using lms.config.Models;

namespace classifyService.Repository
{
	public class ClassifyRepository: IClassifyRepository
	{
        readonly LMSDbContext lMSDbContext;
        readonly IMapper mapper;

        public ClassifyRepository(LMSDbContext lMSDbContext, IMapper mapper)
		{
            this.lMSDbContext = lMSDbContext;
            this.mapper = mapper;
        }

        public async Task<DealerMasterModel> GetDealer(int dealerId)
        {
            var dealer = await lMSDbContext.DealerMasterLists
            .FirstOrDefaultAsync(x => x.DealerCode == dealerId);

            return mapper.Map<DealerMasterList, DealerMasterModel>(dealer);
        }

        public async Task InsertLeadType(LeadTypeResponseModel leadTypeResponseModel, long lead_id)
        {
            ClassifiedLead classifiedLead = new ClassifiedLead();

            classifiedLead.LeadId = lead_id;
            classifiedLead.Probability = leadTypeResponseModel.retail_proba;
            classifiedLead.LeadType = leadTypeResponseModel.predicted_label;

            await lMSDbContext.ClassifiedLeads.AddAsync(classifiedLead);

            await lMSDbContext.SaveChangesAsync();
        }
    }
}


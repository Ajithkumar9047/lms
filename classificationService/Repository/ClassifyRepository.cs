using System;
using AutoMapper;
using System.Reflection;
using lms.config.LMSContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lms.config.Entities;
using lms.config.Models;

namespace classificationService.Repository
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
    }
}



using System;
using System.Numerics;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using lms.config.Entities;
using lms.config.Models;

namespace persistLeadService.AutoMappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

            CreateMap<LeadModel, Lead>();
            CreateMap<Lead, LeadModel>();
            CreateMap<EmsLogModel, EmsPushLog>();
            CreateMap<DealerMasterList, DealerMasterModel>();
            CreateMap<UpdateEmsModel, EmsPushLog>();

            CreateMap<LeadLogModel, LeadLog>();
        }
    }
}



using System;
using System.Numerics;
using System.Reflection;
using AutoMapper;
using lms.config.Entities;
using lms.config.Models;

namespace classifyService.AutoMappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<DealerMasterList, DealerMasterModel>();

        }
    }
}


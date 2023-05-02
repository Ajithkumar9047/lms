
using System;
using System.Numerics;
using System.Reflection;
using AutoMapper;
using lms.config.Entities;
using lms.config.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace classificationService.AutoMappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<DealerMasterList, DealerMasterModel>();

        }
    }
}


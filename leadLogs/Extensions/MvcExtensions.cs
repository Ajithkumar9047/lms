
using System;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using leadReceiptService.Repository;
using leadReceiptService.Services;
using FluentValidation;
using lms.config.Models;
using leadReceiptService.Services;

namespace leadReceiptService.Extensions
{
    public static class MvcExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        [Obsolete]
        public static void ConfigureMvc(this IServiceCollection services)
        {
            services
                .AddMvc(options =>
                {
                    options.Filters.Add(new ResponseCacheAttribute()
                    {
                        NoStore = true,
                        Location = ResponseCacheLocation.None
                    });
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        /// <summary>
        /// Register the classes
        /// </summary>
        /// <param name="services"></param>
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<ILeadLogRepository, LeadLogRepository>();
            services.AddScoped<ILeadLogService, LeadLogService>();
            services.AddScoped<IValidator<LeadRequestModel>, LeadLogValidator>(); 
            services.AddScoped<ILeadDispatchService, LeadDispatchService>();
            services.AddScoped<IProcessInvalidLeadService, ProcessInvalidLeadService>();
            services.AddScoped<IProcessValidLeadService, ProcessValidLeadService>();

        }
    }
}

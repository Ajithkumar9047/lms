
using System;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using persistLeadService.Repository;
using persistLeadService.Services;
using classifyService.Repository;
using classifyService.Services;
using persistLeadService.QueueListeners;
using emsService.Services;
using emsService.Repository;

namespace persistLeadService.Extensions
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
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<ILeadService, LeadService>();
            services.AddScoped<IClassifyRepository, ClassifyRepository>();
            services.AddScoped<IClassifyLeadService, ClassifyLeadService>();
            services.AddScoped<IEmsService, EmsService>();
            services.AddScoped<IEmsRepository, EmsRepository>();

            services.AddHostedService<LeadListenerService>();
        }
    }
}

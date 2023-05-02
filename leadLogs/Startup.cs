
using System;
using System.Data.SqlClient;
using System.Text;
using leadReceiptService.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using leadReceiptService;
using leadReceiptService.AutoMappings;
using lms.config.LMSContext;

namespace leadReceiptService
{
    public class Startup
    {
        private string? _connectionString = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(Startup));
            services.AddCors();
            services.ConfigureMvc();
            services.AddControllers();


            var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("DbConn"));
            //builder.Password = Configuration["DbPassword"];
            //builder.UserID = Configuration["DbUser"];
            _connectionString = builder.ConnectionString;

            services.AddDbContext<LMSDbContext>(options =>
            {
                options.UseSqlServer(_connectionString);

            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LeadLogs API", Version = "v1" });
            });

            services.Register();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LeadLogs API V1");
            });


        }
    }
}


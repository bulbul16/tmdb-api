using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmdb_api.data;
using tmdb_api.domain.configuration;
using tmdb_api.service;

namespace tmdb_api.endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Resolving data and business dependency
            services.AddDBServices(this.Configuration);
            services.AddBusinessServices();

            // Read configuration data
            services.Configure<Settings>(Configuration.GetSection("Settings"));

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
            {
                Version = "v1",
                Title = "TMDB API",
                Description = "This is for API documentation",
                TermsOfService = "None",
                Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                {
                    Name = "Bulbul Ahmed",
                    Email="bulbul.cse@outlook.com",
                    Url= "https://www.grepper.com/profile/bulbul-ahmed"
                }
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TMDB API V1");
            });

            app.UseMvc();
        }
    }
}

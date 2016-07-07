using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace viechef
{
    
    public class Startup
    {
        private string _environment="DEV";
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath) //content root path?
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();  //for web.config file I think;
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            
            // services.AddSwaggerGen(c =>
            // {
            //     c.SingleApiVersion(new Info
            //     {
            //         Version = "v1",
            //         Title = "My Awesome Api",
            //         Description = "A sample API for prototyping.",
            //         TermsOfService = "Some terms ..."
            //     });
            // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            var logger=loggerFactory.CreateLogger(_environment);
            
            if(env.IsDevelopment()){                
                logger.LogInformation("kalite");    
            }
            
            
            // else {
            //     app.UseExceptionHandler("/Home/Error");
            // }
            
            
            

            app.UseMvc();
        }
    }
}

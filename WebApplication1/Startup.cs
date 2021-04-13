using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApplication1.Models;

namespace WebApplication1
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
            // Web API configuration and services
      
            services.AddSingleton(Configuration);

            services.AddDbContext<QuestionDbContext> ( options =>options.
               UseSqlServer(Configuration.GetConnectionString("question")), 
               ServiceLifetime.Scoped);








            //Closing database connections
            /*To free up the resources that a database connection holds,
             * the context instance must be disposed as soon as possible when you are done with it. 
             * The ASP.NET Core built-in dependency injection takes care of that task for you.

            In Startup.cs, you call the AddDbContext extension method to provision the DbContext class in the ASP.NET DI container.
            That method sets the service lifetime to Scoped by default.
            Scoped means the context object lifetime coincides with the web request life time, 
            and the Dispose method will be called automatically at the end of the web request.*/
           
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }









        /*When a database context retrieves table rows and creates entity objects that represent them, 
         * by default it keeps track of whether the entities in memory are in sync with what's in the database.
         * The data in memory acts as a cache and is used when you update an entity. 
         * This caching is often unnecessary in a web application because context instances are typically short-lived (a new one is created and disposed for each request) and the context that reads an entity is typically disposed before that entity is used again.*/
    }
}

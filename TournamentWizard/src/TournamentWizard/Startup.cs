using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Glimpse;
using Microsoft.Extensions.Logging;
using TournamentWizard.Models;

namespace TournamentWizard
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);

        public Startup(IHostingEnvironment env)
        {
            //// Set up configuration sources.
            //var builder = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            //builder.AddEnvironmentVariables();
            //Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<AppDbContext>();

            services.AddGlimpse();
            services.AddMvc();

            //services.AddScoped<IAccountDomainService, AccountDomainService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIISPlatformHandler(options =>
                                      options.AuthenticationDescriptions.Clear());
            app.UseStaticFiles();
            app.UseGlimpse();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default",
                                "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("spa-fallback",
                                "{*anything}",
                                new { controller = "Home", action = "Index" });
                routes.MapWebApiRoute("defaultApi",
                                      "api/{controller}/{id?}");
            });
        }
    }
}

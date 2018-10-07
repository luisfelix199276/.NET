using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Store.CrossCutting.IoC;

namespace StoreSolution
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Singleton Configuration
            services.AddSingleton(_ => Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            //Add framework services.
            services.AddMvc()
             .AddJsonOptions(options =>
             {
                 options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                 options.SerializerSettings.Formatting = Formatting.None;
                 options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
             });
                        
            //IoC
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            IoCConfig.Config(services, connectionString);

            //Parameters Config
            this.GetParameters(services);

            services.AddAuthentication(
                    options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    }
                );

            services.AddOptions();
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            #region [ CORS ]

            app.UseCors("AllowAll");

            #endregion

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
           // app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //    c.RoutePrefix = string.Empty;
            //});

            //app.UseMvc();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "",
                defaults: new { controller = "Customer", action = "Index" });
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Home/Error");
            }
        }

        private void GetParameters(IServiceCollection services)
        {
            //IConfigurationSection parameters = Configuration.GetSection("Parameters");

            //services.Configure<AuthConfig>(parameters.GetSection("Auth"));
            //services.Configure<HashConfig>(parameters.GetSection("Hash"));

            //services.Configure<RequestLocalizationOptions>(options =>
            //{
            //    string languageSystem = "pt-BR";

            //    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(languageSystem);
            //    options.SupportedCultures = new List<CultureInfo> { new CultureInfo(languageSystem) };
            //    options.RequestCultureProviders.Clear();
            //});
        }
    }
}

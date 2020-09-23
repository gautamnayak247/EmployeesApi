using ABB.Api.Core;
using ABB.Domain;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ABB.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConfigurationOptions = new ConfigurationOptions();
            configuration.Bind(ConfigurationOptions);
        }

        public IConfiguration Configuration { get; }
        private IConfigurationOptions ConfigurationOptions { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("ABB.Application");
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(opt =>
                        opt.RegisterValidatorsFromAssembly(Assembly.Load(assembly.GetName())));
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.Authority = "https://gautamnayak.us.auth0.com/";
            //    options.Audience = "https://abb/api";
            //});
            services.AddMediatR(assembly);
            services.AddAutoMapper(typeof(Startup));
            services.ConfigureRegistries(ConfigurationOptions);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Employees api",
                    Description = "Api document",
                    Version = "v1",
                });
                var filePath = Path.Combine(AppContext.BaseDirectory, "ABB.Api.xml");
                c.IncludeXmlComments(filePath);
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("ApiCorsPolicy");
            app.UseTraceIdentifier();
            app.UseNotAcceptableMiddleware();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseExceptionMiddleware();
            //app.UseAuthentication();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                var swaggerJsonPath = "/swagger/v1/swagger.json";
                c.SwaggerEndpoint(swaggerJsonPath, "Employees api");
            });
        }
    }
}

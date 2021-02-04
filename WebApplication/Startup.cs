using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApplication.DataAccess;
using WebApplication.DataAccess.Repositories;
using WebApplication.DataAccess.UnitOfWork;
using WebApplication.Services;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MusicContext>(builder => builder.UseInMemoryDatabase("Music"));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            
            services.AddScoped<ITrackService, TrackService>();
            services.AddScoped<IPlaylistService, PlaylistService>();
            
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            
            // services.AddControllers().AddNewtonsoftJson(options =>
            //     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            // );
            
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("0.1.0", new OpenApiInfo
                {
                    Version = "0.1.0",
                    Title = "Music API",
                    Description = "The API for Music Application built using ASP.NET Core Web API"
                });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/0.1.0/swagger.json", "Music API 0.1.0");
                c.RoutePrefix = string.Empty;
            });
            
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
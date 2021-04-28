using BlogsNTags.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlogsNTags.Services;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogsNTags.API
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
            services.AddRouting(opt =>
            {
                opt.LowercaseUrls = true;
            });

            services.AddControllers(opt=> {
                opt.Filters.Add(new ProducesAttribute("application/json"));
                opt.Filters.Add<Filters.GlobalExceptionFilter>();
            });
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Services.Mappings.BlogsProfile));
            services.AddAutoMapper(typeof(Services.Mappings.TagsProfile));

            services.AddScoped<Services.Interfaces.IBlogService, Services.BlogService>();
            services.AddScoped<Services.Interfaces.ITagService, Services.TagService>();

            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("main"), b => b.MigrationsAssembly("BlogsNTags.Database"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "My BlogsNTags API V1");
                opt.RoutePrefix = String.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

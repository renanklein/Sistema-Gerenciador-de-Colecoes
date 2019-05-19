using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using API_Colecoes.Models;
using API_Colecoes.Services;

namespace API_Colecoes
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
            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<ItemContext>()
                    .BuildServiceProvider();
            services.AddCors(p => p.AddPolicy("Policy", builder => {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .WithExposedHeaders("paginacao");
            }));
            services.AddScoped<IItemTestService, ItemServiceFake>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("Policy");
            app.UseMvc();
        }
    }
}

﻿using AutoMapper;
using Desafio.api.Configuration;
using Desafio.Application.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Desafio
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
            services.AddControllers();
            services.AddIdentitySetup();
            services.InjectDependencies(Configuration);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DesafioDbContext>(options =>
                options.UseNpgsql(connectionString)
            );


            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "Desafio",
                    Description = "Api controle vendas",
                    Contact = new OpenApiContact
                    {
                        Name = "Guilherme",
                        Email = "guilhermebaviera@gmail.com",
                        Url = new System.Uri("https://www.linkedin.com/in/guilhermebaviera/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "",
                        Url = new System.Uri(""),
                    }
                });
            });


            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();
            

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

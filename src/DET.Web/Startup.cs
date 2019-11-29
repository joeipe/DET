using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DET.Read.Data;
using DET.Read.Data.Services;
using DET.Web.Configurations;
using DET.Write.Data;
using DET.Write.Data.CommandHandlers;
using DET.Write.Data.Decorators;
using DET.Write.Data.Services;
using DET.Write.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using SharedKernel;
using SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace DET.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            {
                services.AddDbContext<DETReadContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DETDBConnectionString"))
                );
                services.AddScoped<DETReadUow>();
                services.AddScoped<DETReadData>();

                services.AddDbContext<DETWriteContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DETDBConnectionString"))
                );
                services.AddScoped<DETWriteUow>();
                services.AddScoped<DETWriteData>();
            }

            {
                //services.AddTransient<ICommandHandler<AddRoleCommand>>(provide => 
                //    new DatabaseRetryDecorator<AddRoleCommand>(new AddRoleCommandHandler(provide.GetService<DETWriteUow>())));

                //services.AddTransient<ICommandHandler<AddRoleCommand>, AddRoleCommandHandler>();
                //services.AddTransient<ICommandHandler<UpdateRoleCommand>, UpdateRoleCommandHandler>();
                //services.AddTransient<ICommandHandler<DeleteRoleCommand>, DeleteRoleCommandHandler>();
                //services.AddTransient<ICommandHandler<AddUserCommand>, AddUserCommandHandler>();
                //services.AddTransient<ICommandHandler<UpdateUserCommand>, UpdateUserCommandHandler>();
                //services.AddTransient<ICommandHandler<DeleteUserCommand>, DeleteUserCommandHandler>();
                services.AddScoped<Messages>();
                services.AddHandler();
            }

            services
                .AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.ConfigureLoggerService();

            services.AddAutoMapperSetup();

            services.AddAuthentication(options => 
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            }).AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options => 
            {
                options.SignInScheme = "Cookies";
                options.Authority = "https://localhost:44372";
                options.ClientId = "DETWeb_ClientId";
                options.ResponseType = "code id_token";
                //options.CallbackPath = new PathString("...")
                //options.SignedOutCallbackPath = new PathString("...")
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.SaveTokens = true;
                options.ClientSecret = "secretfordet";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "DET API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();

            app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DET API V1");
            });
        }
    }
}

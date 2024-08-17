using FluentValidation.AspNetCore;
using MagazynEdu.ApplicationServices.API.Domain;
using MagazynEdu.ApplicationServices.API.Mappings;
using MagazynEdu.ApplicationServices.API.Validators;
using MagazynEdu.ApplicationServices.Components.OpenWeather;
using MagazynEdu.DataAccess;
using MagazynEdu.DataAccess.CQRS;
using MagazynEdu.DataAccess.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazynEdu_v2
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
            services.AddMvcCore()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddBookCaseRequestValidator>());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<ICommandExecutor, CommandExecutor>();

            services.AddTransient<IWeatherConnector, WeatherConnector>();

            services.AddAutoMapper(typeof(BooksProfile).Assembly);

            services.AddMediatR(typeof(ResponseBase<>));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDbContext<WarehouseStorageContext>(
                opt =>
                opt.UseSqlServer(this.Configuration.GetConnectionString("WarehouseDatabseConnection")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MagazynEdu", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MagazynEdu v1"));
            }

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

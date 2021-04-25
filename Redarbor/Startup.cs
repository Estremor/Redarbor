using AutoMapper;
using BL;
using BL.Dto;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model;
using Model.Entity;
using Model.Repository;
using Redarbor.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Redarbor
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
            services.AddMvc(setup => {
            }).AddFluentValidation();

            services.AddTransient<IValidator<EmployeeDto>, EmployeeValidation>();

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddTransient<IEmployeeRepository, EmployeeRepository>(src =>
            {
                string connectionString = Configuration.GetConnectionString("Redarbor");
                var connection = new SqlConnection(connectionString: connectionString);
                return new EmployeeRepository(connection);
            });
            services.AddTransient<IEmployeeService, EmployeeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

    public sealed class MapperProfile : Profile
    {
        public MapperProfile() : base()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(x => x.CreatedOn, em => em.MapFrom(src => Convert.ToString(src.CreatedOn)))
                .ForMember(x => x.DeletedOn, em => em.MapFrom(src => Convert.ToString(src.DeletedOn)))
                .ForMember(x => x.Lastlogin, em => em.MapFrom(src => Convert.ToString(src.Lastlogin)))
                .ForMember(x => x.UpdatedOn, em => em.MapFrom(src => Convert.ToString(src.UpdatedOn)));

            CreateMap<EmployeeDto, Employee>()
                .ForMember(x => x.CreatedOn, em => em.MapFrom(src => Convert.ToDateTime(src.CreatedOn)))
                .ForMember(x => x.DeletedOn, em => em.MapFrom(src => Convert.ToDateTime(src.DeletedOn)))
                .ForMember(x => x.Lastlogin, em => em.MapFrom(src => Convert.ToDateTime(src.Lastlogin)))
                .ForMember(x => x.UpdatedOn, em => em.MapFrom(src => Convert.ToDateTime(src.UpdatedOn)));
        }
    }
}

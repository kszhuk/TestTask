using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;
using TestTask.Domain.Repositories;
using TestTask.Infrastructure.Repositories;
using TestTask.WebApi.Contracts.Requests;
using TestTask.WebApi.Filters;
using TestTask.WebApi.Services;
using TestTask.WebApi.Validators;

namespace TestTask.WebApi.Installers
{
    public class ServicesInstaller: IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ISingleOrderService, SingleOrderService>();

            services.AddAutoMapper(typeof(Program));
            services.AddAutoMapper(typeof(OrderRepository));

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<UpdateSingleOrderRequestValidator>();

            services.AddControllers(config =>
            {
                config.Filters.Add(new ModelStateFilter());
            });
        }
    }
}

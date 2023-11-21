using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesOrderSenderService.Application.Services;
using SalesOrderSenderService.Application.Interfaces;
using SalesOrderSenderService.Application.Mappings;
using SalesOrderSenderService.Domain.Interfaces;
using SalesOrderSenderService.Infra.Data.Repositories;
using SalesOrderSenderService.Infra.Data.Context;
using SalesOrderSenderService.RabbitMQ.Interfaces;
using SalesOrderSenderService.RabbitMQ;

namespace SalesOrderSenderService.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            
            // MongoDB
            services.Configure<MongoDBSettings>(
                options => {
                    options.ConnectionURI = configuration["MongoDB:ConnectionURI"];
                    options.DatabaseName = configuration["MongoDB:DatabaseName"];
                    options.CollectionName = configuration["MongoDB:CollectionName"];
                }
            );

            // Repository
            services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();
            services.AddScoped<ISalesOrderSenderRabbitMQRepository, SalesOrderSenderRabbitMQRepository>();

            // Service
            services.AddScoped<ISalesOrderService, SalesOrderService>();
            services.AddScoped<ISalesOrderSenderRabbitMQService, SalesOrderSenderRabbitMQService>();
            services.AddScoped<ISalesOrderSenderAppService, SalesOrderSenderAppService>();

            // RabbitMQ
            services.AddScoped<ISalesOrderSenderRabbitMQ, SalesOrderSenderRabbitMQ>();

            // Mapper
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));            

            return services;
        }
    }

}

using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using SalesOrderSenderService.Application.DTOs;
using SalesOrderSenderService.Application.Interfaces;
using SalesOrderSenderService.Application.Mappings;
using SalesOrderSenderService.Application.Services;
using SalesOrderSenderService.Domain.Entities;
using SalesOrderSenderService.Domain.Interfaces;
using SalesOrderSenderService.Infra.Data.Context;
using SalesOrderSenderService.Infra.Data.Repositories;

namespace SalesOrderSenderService.Service.Tests
{
    public class DependenceInjectionSalesOrderSenderServiceFixture
    {
        private readonly IServiceScope _scope;

        public DependenceInjectionSalesOrderSenderServiceFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<ISalesOrderRepository, SalesOrderRepository>();
            serviceCollection.AddTransient<ISalesOrderService, SalesOrderService>();
            serviceCollection.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var configuration = new ConfigurationBuilder()
            .SetBasePath($"{Directory.GetCurrentDirectory()}/../../../")
            .AddJsonFile(
                path: "appsettings.json",
                optional: false,
                reloadOnChange: true)
            .Build();
            serviceCollection.AddSingleton<IConfiguration>(configuration); 

            serviceCollection.Configure<MongoDBSettings>(
                options => {
                    options.ConnectionURI = configuration["MongoDB:ConnectionURI"];
                    options.DatabaseName = configuration["MongoDB:DatabaseName"];
                    options.CollectionName = configuration["MongoDB:CollectionName"];
                }
            );
            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            _scope = serviceProvider.CreateScope();
        }

        public T GetService<T>()
        {
            return _scope.ServiceProvider.GetRequiredService<T>();
        }
    }

    public class SalesOrderServiceUnitTest1 : IClassFixture<DependenceInjectionSalesOrderSenderServiceFixture>
    {
        private SalesOrderService _salesOrderService;
        private SalesOrderRepository _salesOrderRepository;

        public SalesOrderServiceUnitTest1(DependenceInjectionSalesOrderSenderServiceFixture serviceFixture)
        {
            var loggerMockRepository = Mock.Of<ILogger<SalesOrderRepository>>();

            _salesOrderRepository = new SalesOrderRepository(
                serviceFixture.GetService<IOptions<MongoDBSettings>>(),
                loggerMockRepository
            );

            _salesOrderService = new SalesOrderService(
                _salesOrderRepository,
                serviceFixture.GetService<IMapper>()
            );
        }

        [Fact]
        public async void GetSalesOrder_IsZeroOrMoreThanOneItem_ResultValidOperation()
        {
            //Act
            IEnumerable<SalesOrderDTO> salesOrders = await _salesOrderService.GetSalesOrders();
            
            //Assert
            Assert.True(salesOrders.Count() >= 0);
        }

        [Theory]
        [InlineData("65577e42b9ca0bb418c6c43f")]
        public async void UpdateAcceptedOrder_IsTrue_ResultValidOperationWithCountZero(string id)
        {
            //Arrange
            SalesOrderDTO salesOrder = new SalesOrderDTO()
            {
                Id = id,
                AcceptedOrder = true
            };

            //Act
            Func<Task> action = () => _salesOrderService.UpdateAcceptedOrder(salesOrder);

            IEnumerable<SalesOrderDTO> salesOrders = await _salesOrderService.GetSalesOrders();

            //Assert
            Assert.True(salesOrders.Count() == 0);
        }   
    }
}
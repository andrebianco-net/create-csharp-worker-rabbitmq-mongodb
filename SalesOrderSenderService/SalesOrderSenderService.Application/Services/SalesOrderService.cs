using AutoMapper;
using SalesOrderSenderService.Application.DTOs;
using SalesOrderSenderService.Application.Interfaces;
using SalesOrderSenderService.Domain.Entities;
using SalesOrderSenderService.Domain.Interfaces;

namespace SalesOrderSenderService.Application.Services
{
    public class SalesOrderService : ISalesOrderService
    {
        private ISalesOrderRepository _salesOrderRepository;
        private readonly IMapper _mapper;

        public SalesOrderService(ISalesOrderRepository salesOrderRepository, IMapper mapper)
        {
            _salesOrderRepository = salesOrderRepository;
            _mapper = mapper;
        }        

        public async Task<IEnumerable<SalesOrderDTO>> GetSalesOrders()
        {
            var salesOrdersEntity = await _salesOrderRepository.GetSalesOrdersAsync();
            return _mapper.Map<IEnumerable<SalesOrderDTO>>(salesOrdersEntity);
        }

        public async Task UpdateAcceptedOrder(SalesOrderDTO salesOrderDTO)
        {
            SalesOrder salesOrder = _mapper.Map<SalesOrder>(salesOrderDTO);
            await _salesOrderRepository.UpdateAcceptedOrder(salesOrder);
        }
    }
}
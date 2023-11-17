using AutoMapper;
using SalesOrderSenderService.Application.DTOs;
using SalesOrderSenderService.Domain.Entities;

namespace SalesOrderSenderService.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<SalesOrder, SalesOrderDTO>().ReverseMap();
            
        }
    }
}
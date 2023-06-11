using AutoMapper;
using TestTask.Domain.Models;
using TestTask.WebApi.Contracts.Requests;
using TestTask.WebApi.Contracts.Responses;

namespace TestTask.WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, UpdateSingleOrderRequest>();
            CreateMap<UpdateSingleOrderRequest, Order>();
            CreateMap<Order, SingleOrderResponse>();
            CreateMap<SingleOrderResponse, Order>();
        }
    }
}

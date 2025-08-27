using AutoMapper;
using EcommerceOrder.API.DTOs;
using EcommerceOrder.API.Models;

namespace EcommerceOrder.API.Helpers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>().ReverseMap();
        }
    }
}

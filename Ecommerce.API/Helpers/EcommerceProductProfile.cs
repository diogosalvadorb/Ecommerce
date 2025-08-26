using AutoMapper;
using Ecommerce.API.DTOs;
using Ecommerce.API.Models;

namespace Ecommerce.API.Helpers
{
    public class EcommerceProductProfile : Profile
    {
        public EcommerceProductProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}

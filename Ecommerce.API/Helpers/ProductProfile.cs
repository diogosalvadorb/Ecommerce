using AutoMapper;
using Ecommerce.API.DTOs;
using Ecommerce.API.Models;

namespace Ecommerce.API.Helpers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}

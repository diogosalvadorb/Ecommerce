using Ecommerce.API.DTOs;
using Ecommerce.API.Models;

namespace Ecommerce.API.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetByIdAsync(Guid id);
        Task<ProductDTO> AddProductAsync(ProductDTO productDTO);
        Task UpdateProductAsync(ProductDTO productDTO);
        Task DeleteProductAsync(Guid id);
    }
}

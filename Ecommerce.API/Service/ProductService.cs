using Ecommerce.API.DTOs;
using Ecommerce.API.Repository.Interface;
using Ecommerce.API.Service.Interface;

namespace Ecommerce.API.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os produtos: {ex.Message}", ex);
            }
        }

        public async Task<ProductDTO> GetByIdAsync(Guid id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar produto pelo Id: {ex.Message}", ex);
            }
        }

        public async Task<ProductDTO> AddProductAsync(ProductDTO productDTO)
        {
            try
            {
                return await _repository.AddProductAsync(productDTO);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adicionar produto: {ex.Message}", ex);
            }
        }

        public async Task UpdateProductAsync(ProductDTO productDTO)
        {
            try
            {
                await _repository.UpdateProductAsync(productDTO);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar produto: {ex.Message}", ex);
            }
        }

        public async Task DeleteProductAsync(Guid id)
        {
            try
            {
                await _repository.DeleteProductAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir produto: {ex.Message}", ex);
            }
        }
    }
}

using EcommerceOrder.API.DTOs;
using EcommerceOrder.API.Repository.Interface;
using EcommerceOrder.API.Service.Interface;

namespace EcommerceOrder.API.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly HttpClient _httpClient;
        public OrderService(IOrderRepository repository, HttpClient httpClient)
        {
            _repository = repository;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os Pedidos: {ex.Message}", ex);
            }
        }

        public async Task<OrderDTO> GetByIdAsync(Guid id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar Pedido pelo Id: {ex.Message}", ex);
            }
        }

        public Task<OrderDTO> AddOrderAsync(OrderDTO order)
        {
            // 1. Verificar disponibilidade no Product.API
            // 2. Criar pedido
            // 3. Reduzir estoque
            throw new NotImplementedException();
        }
    }
}

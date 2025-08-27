using EcommerceOrder.API.DTOs;

namespace EcommerceOrder.API.Service.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllAsync();
        Task<OrderDTO> GetByIdAsync(Guid id);
        Task<OrderDTO> AddOrderAsync(OrderDTO order);
    }
}

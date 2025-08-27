using EcommerceOrder.API.DTOs;
using EcommerceOrder.API.Models;

namespace EcommerceOrder.API.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDTO>> GetAllAsync();
        Task<OrderDTO> GetByIdAsync(Guid id);
        Task<OrderDTO> AddAsync(OrderDTO orderDTO);
    }
}

using AutoMapper;
using EcommerceOrder.API.Context;
using EcommerceOrder.API.DTOs;
using EcommerceOrder.API.Models;
using EcommerceOrder.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceOrder.API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        private IMapper _mapper;
        public OrderRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            List<Order> orders = await _context.Orders.ToListAsync();
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetByIdAsync(Guid id)
        {
            Order order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<OrderDTO>(order);

        }

        public async Task<OrderDTO> AddAsync(OrderDTO orderDTO)
        {
            Order order = _mapper.Map<Order>(orderDTO);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderDTO>(order);
        }
    }
}

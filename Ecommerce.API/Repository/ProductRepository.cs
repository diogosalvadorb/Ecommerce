using AutoMapper;
using Ecommerce.API.Context;
using Ecommerce.API.DTOs;
using Ecommerce.API.Models;
using Ecommerce.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private IMapper _mapper;
        public ProductRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }


        public async Task<ProductDTO> GetByIdAsync(Guid id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> AddProductAsync(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task UpdateProductAsync(ProductDTO productDTO)
        {
            try
            {
                var existProduct = await _context.Products.FindAsync(productDTO.Id);
                if (existProduct == null)
                {
                    throw new ArgumentException("Não foi possível retornar o Produto pelo ID");
                }

                _mapper.Map(productDTO, existProduct);

                _context.Products.Update(existProduct);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível atualizar o Produto!");
            }
        }

        public async Task DeleteProductAsync(Guid id)
        {
            try
            {
                var product = _context.Products.FindAsync(id);
                _context.Products.Remove(product.Result);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível excluir o Produto!");
            }
            
        }
    }
}

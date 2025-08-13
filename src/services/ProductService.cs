using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductAppAsync.src.config.DB;
using ProductAppAsync.src.interfaces;
using ProductAppAsync.src.models;

namespace ProductAppAsync.src.services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> CreateProduct(Product createdProduct)
        {
            createdProduct.ProductId = Guid.NewGuid();
            await _context.Products.AddAsync(createdProduct);
            await _context.SaveChangesAsync();
            return createdProduct;
        }
    }
}
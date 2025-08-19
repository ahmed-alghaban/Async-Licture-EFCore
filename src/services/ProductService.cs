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
            return await _context.Products.Include(p=> p.AssociatedCategory).ToListAsync();
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            return await _context.Products.FindAsync(productId) ?? throw new Exception("Product not found");
        }

        public async Task<Product> CreateProduct(Product createdProduct)
        {
            createdProduct.ProductId = Guid.NewGuid();
            await _context.Products.AddAsync(createdProduct);
            await _context.SaveChangesAsync();
            return createdProduct;
        }

        public async Task<Product> UpdateProducts(Product updatedProduct, Guid productId)
        {
            var product = await _context.Products.FindAsync(productId) ?? throw new Exception("Product not found");
            product.Name = updatedProduct.Name ?? product.Name;
            product.Price = updatedProduct.Price > 0 ? updatedProduct.Price : product.Price;
            product.Description = updatedProduct.Description ?? product.Description;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(Guid productId) {
            var product = await _context.Products.FindAsync(productId) ?? throw new Exception("Product not found");
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
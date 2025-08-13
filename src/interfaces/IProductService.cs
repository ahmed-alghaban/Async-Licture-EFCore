using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAppAsync.src.models;

namespace ProductAppAsync.src.interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product> CreateProduct(Product createdProduct);
    }
}
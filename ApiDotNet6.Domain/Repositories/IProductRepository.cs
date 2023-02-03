using System;
using ApiDotNet6.Domain.Entities;

namespace ApiDotNet6.Domain.Repositories
{
	public interface IProductRepository
	{
        Task<Product> GetByIdAsync(int id);
        Task<ICollection<Product>> GetProductsAsync();
        Task<Product> CreateProductAsync(Product product);
        Task EditAsync(Product product);
        Task DeleteAsync(Product product);
    }
}


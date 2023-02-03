using System;
using ApiDotNet6.Domain.Entities;
using ApiDotNet6.Domain.Repositories;
using ApiDotNet6.infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiDotNet6.infra.Data.Repositories
{
	public class ProductRepository : IProductRepository
	{
        private readonly ApplicationDbContext _db;

		public ProductRepository(ApplicationDbContext db) 
		{
            _db = db;
		}

        public async Task<Product> CreateProductAsync(Product product)
        {
            _db.Add(product);
            await _db.SaveChangesAsync();

            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            _db.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Product product)
        {
            _db.Update(product);
            await _db.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Product>> GetProductsAsync()
        {
            return await _db.Products.ToListAsync();
        }
    }
}


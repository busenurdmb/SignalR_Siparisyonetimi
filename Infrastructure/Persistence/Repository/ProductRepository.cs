using Application.Features.Mediator.Products.Queries.GetProductsWithCategories;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class ProductRepository : EfEntityRepository<Product, SignalRContext>, IProductRepository
    {
        
        public ProductRepository(SignalRContext context) : base(context)
        {
           
        }

        public async Task<List<GetListProductsWithCategoriesResponse>> GetProductsWithCategories()
        {
            var list = await _context.Products.Include(p => p.Category).Select(p => new GetListProductsWithCategoriesResponse
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                ProductStatus = p.ProductStatus,
                CategoryID = p.CategoryID,
                CategoryName = p.Category.CategoryName

            }).ToListAsync();


            return list;

        }

        public async Task<List<Product>> GetProductsWithCategories2()
        {
            var list = await _context.Products.Include(p => p.Category).ToListAsync();
            return list;
        }
    }
}

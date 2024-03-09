using Application.Features.Mediator.Products.Queries.GetProductsWithCategories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        //Task<List<GetListProductsWithCategoriesResponse>> GetProductsWithCategories();
        Task<List<Product>> GetProductsWithCategories2();
    }
}

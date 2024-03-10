using Application.Features.Mediator.Categories.Queries.GetProductsWithCategories;
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

        public decimal ProductAvgPriceByHamburger()
        {
            var categoryıd = _context.Categories.Where(x => x.CategoryName == "Hamburger").Select(z=>z.CategoryID).FirstOrDefault();
            var value = _context.Products.Where(x => x.CategoryID == categoryıd).Average(w => w.Price);
            return value;
        }

        public int ProductCount()
        {
            return _context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            var id=_context.Categories.Where(c=>c.CategoryName== "İçecek").Select(z=>z.CategoryID).FirstOrDefault();
            var value = _context.Products.Where(x => x.CategoryID == id).Count();
            return value;
        }

        public int ProductCountByCategoryNameHamburger()
        {
            var id = _context.Categories.Where(c => c.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault();
            var value = _context.Products.Where(x => x.CategoryID == id).Count();
            return value;
        }

        public string ProductNameByMaxPrice()
        {
            var max = _context.Products.Max(y => y.Price);
            var value=_context.Products.Where(x=>x.Price==max).Select(x=>x.ProductName).FirstOrDefault();
            return value;

        }

        public string ProductNameByMinPrice()
        {
            var min = _context.Products.Min(y => y.Price);
            var value = _context.Products.Where(x => x.Price == min).Select(x => x.ProductName).FirstOrDefault();
            return value;
        }

        public decimal ProductPriceAvg()
        {
           var value=_context.Products.Average(x=>x.Price);
            return value;
        }

        public decimal ProductPriceBySteakBurger()
        {
            var value= _context.Products.Where(x => x.ProductName == "Steak Burger").Select(y => y.Price).FirstOrDefault();
            return value;
        }

        public decimal TotalPriceByDrinkCategory()
        {
            var id = _context.Categories.Where(c => c.CategoryName == "İçecek").Select(z => z.CategoryID).FirstOrDefault();
            var value=_context.Products.Where(x=>x.CategoryID==id).Sum(y => y.Price);
            return value;
        }

        public decimal TotalPriceBySaladCategory()
        {
            var id = _context.Categories.Where(c => c.CategoryName == "Salata").Select(z => z.CategoryID).FirstOrDefault();
            var value = _context.Products.Where(x => x.CategoryID == id).Sum(y => y.Price);
            return value;
        }
    }
}

using Application.Repositories;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class CategoryRepository : EfEntityRepository<Category, SignalRContext>, ICategoryRepository
    {
        public CategoryRepository(SignalRContext context) : base(context)
        {
        }

        public  int CategoryCount()
        {
            return _context.Categories.Count();
        }
    }
}

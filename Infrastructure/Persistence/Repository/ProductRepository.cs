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
    public class ProductRepository : EfEntityRepository<Product, SignalRContext>, IProductRepository
    {
        public ProductRepository(SignalRContext context) : base(context)
        {
        }
    }
}

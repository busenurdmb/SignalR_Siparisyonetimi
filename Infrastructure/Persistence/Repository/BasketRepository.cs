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
    public class BasketRepository : EfEntityRepository<Basket, SignalRContext>, IBasketRepository
    {
        public BasketRepository(SignalRContext context) : base(context)
        {
        }
    }
}

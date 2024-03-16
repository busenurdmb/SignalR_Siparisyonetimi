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
    public class BasketRepository : EfEntityRepository<Basket, SignalRContext>, IBasketRepository
    {
        public BasketRepository(SignalRContext context) : base(context)
        {
        }

        public  async Task<List<Basket>> BasketListByMenuTableWithProductName(int id)
        {
            var values =await _context.Baskets.Where(b => b.MenuTableID == id).Include(x=>x.Product).ToListAsync();
            return values;
        }

       

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            var values=_context.Baskets.Where(b=>b.MenuTableID == id).ToList();
            return values;
        }
    }
}

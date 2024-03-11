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
    public class OrderRepository : EfEntityRepository<Order, SignalRContext>, IOrderRepository
    {
        public OrderRepository(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            return _context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public decimal LastOrderPrice()
        {
            return _context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotalPrice()
        {
            return 0;
        }

        public int TotalOrderCount()
        {
            return _context.Orders.Count();
        }
    }
}

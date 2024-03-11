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
    public class OrderDetailRepository : EfEntityRepository<OrderDetail, SignalRContext>, IOrderDetailRepository
    {
        public OrderDetailRepository(SignalRContext context) : base(context)
        {
        }
    }
}

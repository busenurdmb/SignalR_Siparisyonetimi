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
    public class MoneyCaseRepository : EfEntityRepository<MoneyCase, SignalRContext>, IMoneyCaseRepository
    {
        public MoneyCaseRepository(SignalRContext context) : base(context)
        {
        }

        public decimal TotalMoneyCaseAmount()
        {
            return _context.MoneyCases.Select(c => c.TotalAmount).FirstOrDefault();
        }
    }
}

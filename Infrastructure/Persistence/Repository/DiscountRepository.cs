using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class DiscountRepository : EfEntityRepository<Discount, SignalRContext>, IDiscountRepository
    {
        public DiscountRepository(SignalRContext context) : base(context)
        {
        }

		public async Task ChangeStatusToFalse(int id)
		{
			var value = await _context.Discounts.FindAsync(id);
			value.Status = false;
			await _context.SaveChangesAsync();
		}

		public async Task ChangeStatusToTrue(int id)
		{
			var value = await _context.Discounts.FindAsync(id);
			value.Status = true;
			await _context.SaveChangesAsync();
		}

		public List<Discount> GetListByStatusTrue()
		{
			var value = _context.Discounts.Where(x => x.Status == true).ToList();
			return value;
		}
	}
}

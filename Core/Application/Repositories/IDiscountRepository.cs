using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IDiscountRepository : IEntityRepository<Discount>
    {
		Task ChangeStatusToTrue(int id);
		Task ChangeStatusToFalse(int id);
		List<Discount> GetListByStatusTrue();
	}
}

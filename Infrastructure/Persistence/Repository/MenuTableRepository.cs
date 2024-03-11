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
    public class MenuTableRepository : EfEntityRepository<MenuTable, SignalRContext>, IMenuTableRepository
    {
        public MenuTableRepository(SignalRContext context) : base(context)
        {
        }

        public int MenuTableCount()
        {
            return _context.MenuTables.Count();
        }
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IBasketRepository:IEntityRepository<Basket>
    {
        List<Basket> GetBasketByMenuTableNumber(int id);
        Task<List<Basket>> BasketListByMenuTableWithProductName(int id);
        
        
    }
}

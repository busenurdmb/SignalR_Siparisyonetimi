using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Orders.Queries.GetById
{
   public class GetByIdOrderResponse
    {
        public int OrderID { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }

       
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

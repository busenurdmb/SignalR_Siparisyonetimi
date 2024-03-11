using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Orders.Commands.Update
{
    public class UpdatedOrderResponse
    {
        public int OrderID { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }


        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

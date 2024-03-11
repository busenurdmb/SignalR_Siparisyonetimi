using Application.Features.Mediator.Categories.Queries.GetActiveCatgeoryCount;
using Application.Features.Mediator.Categories.Queries.GetPassiveCatgeoryCount;
using Application.Features.Mediator.Categories.Queries.GetProductCount;
using Application.Features.Mediator.MenuTables.Queries.GetMenuTableCount;
using Application.Features.Mediator.MoneyCases.Queries;
using Application.Features.Mediator.Orders.Queries.GetActiveOrderCount;
using Application.Features.Mediator.Orders.Queries.GetLastOrderPrice;
using Application.Features.Mediator.Orders.Queries.GetOrderCount;
using Application.Features.Mediator.Products.Queries.GetProductAvgPriceByHamburger;
using Application.Features.Mediator.Products.Queries.GetProductCount;
using Application.Features.Mediator.Products.Queries.GetProductCountByCategoryNameDrink;
using Application.Features.Mediator.Products.Queries.GetProductCountByCategoryNameHamburger;
using Application.Features.Mediator.Products.Queries.GetProductNameByMaxPrice;
using Application.Features.Mediator.Products.Queries.GetProductNameByMinPrice;
using Application.Features.Mediator.Products.Queries.GetProductPriceAvg;
using Application.Features.Mediator.Products.Queries.GetProductPriceBySteakBurger;
using Application.Features.Mediator.Products.Queries.GetTotalPriceByDrinkCategory;
using Application.Features.Mediator.Products.Queries.GetTotalPriceBySaladCategory;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs
{
    //hub:bir sunucu görevi görücek yani dağıtım işlemini hub sınıfı hangisiyse onun üzerinden sağlıyıcaz.
    public class SignalRHub:Hub
    {
        private readonly IMediator _mediator;

        public SignalRHub(IMediator mediator)
        {
            _mediator = mediator;
        }
        //client tarafına geldiğim zaman SendCategoryCount methodun çağırıcam bu m ethoda invoke ile istek at methodun içindeki ReceiveCatgeoryCount kullan.
        public async Task SendCategoryCount()
        {
          var value = await _mediator.Send(new GetCategoryCountQuery());

            await Clients.All.SendAsync("ReceiveCategoryCount", value.categorycount);
            
            
        }
        public async Task SendStatistic()
        {
            var value = await _mediator.Send(new GetCategoryCountQuery());
            await Clients.All.SendAsync("ReceiveCategoryCount", value.categorycount);

            var value2 = await _mediator.Send(new GetProductCountQuery());
            await Clients.All.SendAsync("ReceiveProductCount", value2.count);

            var value3 = await _mediator.Send(new GetActiveCategoryCountQuery());
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3.count);

            var value4 = await _mediator.Send(new GetPassiveCategoryCountQuery());
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4.count);

            var value5 = await _mediator.Send(new GetProductCountByCategoryNameHamburgerQuery());
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value5.counthamburger);

            var value6 = await _mediator.Send(new GetProductCountByCategoryNameDrinkQuery());
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value6.countdrink);

            var value7 = await _mediator.Send(new GetProductPriceAvgQuery());
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value7.avg.ToString("0.00") + "₺");

            var value8 = await _mediator.Send(new GetProductNameByMaxPriceQuery());
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value8.name);

            var value9 = await _mediator.Send(new GetProductNameByMinPriceQuery());
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value9.name);

            var value10 = await _mediator.Send(new GetProductAvgPriceByHamburgerQuery());
            await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", value10.avgprice.ToString("0.00")+ "₺");

            var value11 = await _mediator.Send(new GetOrderCountQuery());
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value11.count);

            var value12 = await _mediator.Send(new GetActiveOrderCountQuery());
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value12.count);

            var value13 = await _mediator.Send(new GetLastOrderPriceQuery());
            await Clients.All.SendAsync("ReceiveLastOrderPrice", value13.price.ToString("0.00") + "₺");
          
           var value14 = await _mediator.Send(new GetTotalMoneyCaseAmountQuery());
           await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14.Moneycasa.ToString("0.00") + "₺");

            var value16 = await _mediator.Send(new GetProductNameByMaxPriceQuery());
            await Clients.All.SendAsync("ReceiveMenuTableCount", value16.name);
        }
        public async Task SendProgress()
        {

            var value = await _mediator.Send(new GetTotalMoneyCaseAmountQuery());
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.Moneycasa.ToString("0.00") + "₺");

            var value2 = await _mediator.Send(new GetActiveOrderCountQuery());
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value2.count);

            var value3 = await _mediator.Send(new GetMenuTableCountQuery());
            await Clients.All.SendAsync("ReceiveMenuTableCount", value3.count);

            var value5 = await _mediator.Send(new GetProductPriceAvgQuery());
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value5.avg.ToString("0.00")+"₺");


            var value6 = await _mediator.Send(new GetProductAvgPriceByHamburgerQuery());
            await Clients.All.SendAsync("ReceiveAvgPriceByHamburger", value6.avgprice);


            var value7 = await _mediator.Send(new GetProductCountByCategoryNameDrinkQuery());
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value7.countdrink);


            var value8 = await _mediator.Send(new GetOrderCountQuery());
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value8.count);

            var value9 = await _mediator.Send(new GetProductPriceBySteakBurgerQuery());
            await Clients.All.SendAsync("ReceiveProductPriceBySteakBurger", value9.price);

            var value10 = await _mediator.Send(new GetTotalPriceByDrinkCategoryQuery());
            await Clients.All.SendAsync("ReceiveTotalPriceByDrinkCategory", value10.pricesum);

            var value11 = await _mediator.Send(new GetTotalPriceBySaladCategoryQuery());
            await Clients.All.SendAsync("ReceiveTotalPriceBySaladCategory", value11.pricesalad);

        }
    }
}

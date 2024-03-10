using Application.Features.Mediator.Categories.Queries.GetCategoryCount;
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
    }
}

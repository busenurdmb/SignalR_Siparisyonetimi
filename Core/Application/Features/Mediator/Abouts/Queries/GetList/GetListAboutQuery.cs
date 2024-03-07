using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Abouts.Queries.GetList
{
    public class GetListAboutQuery:IRequest<List<GetListAboutListItemDto>>
    {
        public class GetListAboutQueryHandler : IRequestHandler<GetListAboutQuery, List<GetListAboutListItemDto>>
        {
            private readonly IAboutRepository _aboutRepository;

            public GetListAboutQueryHandler(IAboutRepository aboutRepository)
            {
                _aboutRepository = aboutRepository;
            }

            public async Task<List<GetListAboutListItemDto>> Handle(GetListAboutQuery request, CancellationToken cancellationToken)
            {
              var values=  await _aboutRepository.GetAllAsync();
                return values.Select(x => new GetListAboutListItemDto
                {
                    AboutID = x.AboutID,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Title = x.Title
                }).ToList();
            }
        }
    }
}

using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Abouts.Queries.GetById
{
    public class GetByIdAboutQuery:IRequest<GetByIdAboutResponse>
    {
        public int Id { get; set; }
        public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdAboutQuery, GetByIdAboutResponse>
        {
            private readonly IAboutRepository _aboutRepository;

            public GetByIdBrandQueryHandler(IAboutRepository aboutRepository)
            {
                _aboutRepository = aboutRepository;
            }

            public async Task<GetByIdAboutResponse> Handle(GetByIdAboutQuery request, CancellationToken cancellationToken)
            {
                var values = await _aboutRepository.GetByFilterAsync(b=>b.AboutID==request.Id);
                return new GetByIdAboutResponse
                {
                    AboutID = values.AboutID,
                    Description = values.Description,
                    ImageUrl = values.ImageUrl,
                    Title = values.Title
                };
        }
    }
    }
}


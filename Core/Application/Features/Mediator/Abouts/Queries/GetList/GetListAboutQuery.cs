using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Abouts.Queries.GetList
{
    public class GetListAboutQuery:IRequest<List<GetListAboutResponse>>
    {
        public class GetListAboutQueryHandler : IRequestHandler<GetListAboutQuery, List<GetListAboutResponse>>
        {
            private readonly IAboutRepository _aboutRepository;
            private readonly IMapper _mapper;

            public GetListAboutQueryHandler(IAboutRepository aboutRepository, IMapper mapper)
            {
                _aboutRepository = aboutRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListAboutResponse>> Handle(GetListAboutQuery request, CancellationToken cancellationToken)
            {
              var About=  await _aboutRepository.GetAllAsync();
                return _mapper.Map<List<GetListAboutResponse>>(About);
            }
        }
    }
}

using Application.Features.Mediator.Features.Commands.Delete;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Features.Commands.Delete
{
    public class DeletedFeatureCommand : IRequest<DeletedFeatureResponse>
    {
        public int Id { get; set; }

        public class DeletedFeatureCommandHandler : IRequestHandler<DeletedFeatureCommand, DeletedFeatureResponse>
        {
            private readonly IFeatureRepository _FeatureRepository;
            private readonly IMapper _mapper;

            public DeletedFeatureCommandHandler(IFeatureRepository FeatureRepository, IMapper mapper)
            {
                _FeatureRepository = FeatureRepository;
                _mapper = mapper;
            }

            public async Task<DeletedFeatureResponse> Handle(DeletedFeatureCommand request, CancellationToken cancellationToken)
            {
                Feature? Feature = await _FeatureRepository.GetByFilterAsync(c => c.FeatureID == request.Id);

                await _FeatureRepository.RemoveAsync(Feature);

                return _mapper.Map<DeletedFeatureResponse>(Feature);

            }
        }
    }
}

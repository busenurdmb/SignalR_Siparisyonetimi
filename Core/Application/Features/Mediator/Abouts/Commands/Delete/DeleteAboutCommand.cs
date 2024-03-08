using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Abouts.Commands.Delete
{
    public class DeleteAboutCommand:IRequest<DeleteAboutResponse>
    {
        public int Id { get; set; }

        public DeleteAboutCommand(int ıd)
        {
            Id = ıd;
        }
        public class DeleteAboutCommandHandler : IRequestHandler<DeleteAboutCommand, DeleteAboutResponse>
        {
            private readonly IAboutRepository _aboutRepository;

            public DeleteAboutCommandHandler(IAboutRepository aboutRepository)
            {
                _aboutRepository = aboutRepository;
            }

            public async Task<DeleteAboutResponse> Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
            {
                var values = await _aboutRepository.GetByIdAsync(request.Id);
                await _aboutRepository.RemoveAsync(values);
                return new DeleteAboutResponse
                {
                    AboutID = request.Id,

                };
            }
        }
    }
}

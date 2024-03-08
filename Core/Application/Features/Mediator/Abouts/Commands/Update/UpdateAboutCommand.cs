using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Abouts.Commands.Update
{
    public class UpdateAboutCommand:IRequest<UpdateAboutResponse>
    {
        public int AboutID { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, UpdateAboutResponse>
        {
            private readonly IAboutRepository _aboutRepository;

            public UpdateAboutCommandHandler(IAboutRepository aboutRepository)
            {
                _aboutRepository = aboutRepository;
            }

            public async Task<UpdateAboutResponse> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
            {
                //var values = await _aboutRepository.GetByFilterAsync(b => b.AboutID == request.AboutID);
                var values = await _aboutRepository.GetByIdAsync(request.AboutID);
              values.Description = request.Description;
                values.Title = request.Title;   
                values.ImageUrl = request.ImageUrl;
               await _aboutRepository.UpdateAsync(values);
                return new UpdateAboutResponse
                {
                    AboutID = values.AboutID,
                    Title = values.Title,
                    Description = values.Description,
                    ImageUrl = values.ImageUrl

                };
            }
        }
    }
}

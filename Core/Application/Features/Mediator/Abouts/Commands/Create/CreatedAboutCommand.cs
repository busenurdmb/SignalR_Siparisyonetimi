using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Abouts.Commands.Create
{
    public class CreatedAboutCommand : IRequest<CreatedAboutResponse>
    {
        //public int AboutID { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public class CreatedAboutCommandHandler : IRequestHandler<CreatedAboutCommand, CreatedAboutResponse>
        {
            private readonly IAboutRepository _aboutRepository;

            public CreatedAboutCommandHandler(IAboutRepository aboutRepository)
            {
                _aboutRepository = aboutRepository;
            }

            public async Task<CreatedAboutResponse> Handle(CreatedAboutCommand request, CancellationToken cancellationToken)
            {
                // Yeni About nesnesi oluştur ve veritabanına ekle
                var newAbout = new About
                {
                    // AboutID otomatik olarak atanacaktır, burada elle bir değer atamaya gerek yok
                    Description = request.Description,
                    ImageUrl = request.ImageUrl,
                    Title = request.Title
                };
                await _aboutRepository.CreateAsync(newAbout);

                // Oluşturulan hakkında yanıtını döndür
                return new CreatedAboutResponse
                {
                    AboutID = newAbout.AboutID, // Otomatik artan AboutID değerini kullan
                    Description = newAbout.Description,
                    ImageUrl = newAbout.ImageUrl,
                    Title = newAbout.Title
                };
                //        await _aboutRepository.CreateAsync(new About
                //        {
                //            Description=request.Description,
                //            ImageUrl=request.ImageUrl,
                //            Title=request.Title

                //        });
                //        // Oluşturulan hakkında yanıtını döndür
                //    return new CreatedAboutResponse
                //{

                //    Description = request.Description,
                //    ImageUrl = request.ImageUrl,
                //       Title = request.Title
                //};
                //    }
            }
        }
    }
}

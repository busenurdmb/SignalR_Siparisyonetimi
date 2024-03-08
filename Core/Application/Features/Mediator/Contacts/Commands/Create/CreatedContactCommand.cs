using Application.Features.Mediator.Categories.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Contacts.Commands.Create
{
    public class CreatedContactCommand : IRequest<CreatedContactResponse>
    {
       
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string FooterTitle { get; set; }
        public string FooterDescription { get; set; }
        public string OpenDays { get; set; }
        public string OpenDaysDescription { get; set; }
        public string OpenHours { get; set; }

        public class CreatedContactCommandHandler : IRequestHandler<CreatedContactCommand, CreatedContactResponse>
        {
            private readonly IContactRepository _ContactRepository;
            private readonly IMapper _mapper;

            public CreatedContactCommandHandler(IContactRepository ContactRepository, IMapper mapper)
            {
                _ContactRepository = ContactRepository;
                _mapper = mapper;
            }

            public async Task<CreatedContactResponse> Handle(CreatedContactCommand request, CancellationToken cancellationToken)
            {
                var Contact = _mapper.Map<Contact>(request);
                await _ContactRepository.CreateAsync(Contact);
                return _mapper.Map<CreatedContactResponse>(Contact);
            }
        }
    }
}

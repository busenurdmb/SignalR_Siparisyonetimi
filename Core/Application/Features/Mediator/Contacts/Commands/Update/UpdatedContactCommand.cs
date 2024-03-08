using Application.Features.Mediator.Categories.Commands.Update;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Contacts.Commands.Update
{
    public class UpdatedContactCommand : IRequest<UpdatedContactResponse>
    {
        public int ContactID { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string FooterTitle { get; set; }
        public string FooterDescription { get; set; }
        public string OpenDays { get; set; }
        public string OpenDaysDescription { get; set; }
        public string OpenHours { get; set; }

        public class UpdatedContactCommandHandler : IRequestHandler<UpdatedContactCommand, UpdatedContactResponse>
        {
            private readonly IContactRepository _ContactRepository;
            private readonly IMapper _mapper;

            public UpdatedContactCommandHandler(IContactRepository ContactRepository, IMapper mapper)
            {
                _ContactRepository = ContactRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedContactResponse> Handle(UpdatedContactCommand request, CancellationToken cancellationToken)
            {
                Contact? Contact = await _ContactRepository.GetByFilterAsync(c => c.ContactID == request.ContactID);

                Contact = _mapper.Map(request, Contact);

                await _ContactRepository.UpdateAsync(Contact);

                return _mapper.Map<UpdatedContactResponse>(Contact);

            }
        }
    }
}

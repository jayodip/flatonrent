using AutoMapper;
using MediatR;
using RentFlats.Application.ApplicationUser;
using RentFlats.Application.Dtos;
using RentFlats.Domain.Entities;
using RentFlats.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Application.CQRS.Commands.CreateFlat
{
    public class CreateFlatCommandHandler : IRequestHandler<CreateFlatCommand>
    {
        private readonly IMapper _mapper;
        private readonly IFlatRepository _flatRepository;
        private readonly IUserContext _userContext;

        public CreateFlatCommandHandler(IMapper mapper, IFlatRepository flatRepository, IUserContext userContext)
        {
            _mapper = mapper;
            _flatRepository = flatRepository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateFlatCommand request, CancellationToken cancellationToken)
        {
            var flat = _mapper.Map<Flat>(request);
            flat.CreatedById = _userContext.GetCurrentUser()?.Id;
            await _flatRepository.Create(flat);

            return Unit.Value;
        }
    }
}

using AutoMapper;
using MediatR;
using RentFlats.Application.Dtos;
using RentFlats.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Application.CQRS.Queries.GetFlatByEncodedName
{
    public class GetFlatByIdQueryHandler : IRequestHandler<GetFlatByIdQuery, FlatDto>
    {
        private readonly IFlatRepository _flatRepository;
        private readonly IMapper _mapper;

        public GetFlatByIdQueryHandler(IFlatRepository flatRepository, IMapper mapper)
        {
            _flatRepository = flatRepository;
            _mapper = mapper;
        }
        public async Task<FlatDto> Handle(GetFlatByIdQuery request, CancellationToken cancellationToken)
        {
            var flat = await _flatRepository.GetById(request.Id);
            var dto = _mapper.Map<FlatDto>(flat);
            return dto;
        }
    }
}

using AutoMapper;
using MediatR;
using RentFlats.Application.Dtos;
using RentFlats.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Application.CQRS.Queries.GetAllFlats
{
    public class GetAllFlatsQueryHandler : IRequestHandler<GetAllFlatsQuery, IEnumerable<FlatDto>>
    {
        private readonly IMapper _mapper;
        private readonly IFlatRepository _flatRepository;

        public GetAllFlatsQueryHandler(IMapper mapper, IFlatRepository flatRepository)
        {
            _mapper = mapper;
            _flatRepository = flatRepository;
        }
        public async Task<IEnumerable<FlatDto>> Handle(GetAllFlatsQuery request, CancellationToken cancellationToken)
        {
            var flats = await _flatRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<FlatDto>>(flats);
            return dtos;
        }
    }
}

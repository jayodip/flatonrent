using MediatR;
using RentFlats.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Application.CQRS.Queries.GetFlatByEncodedName
{
    public class GetFlatByIdQuery : IRequest<FlatDto>
    {
        public int Id { get; set; }
        public GetFlatByIdQuery(int id)
        {
            Id = id;
        }
    }
}

using MediatR;
using RentFlats.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Application.CQRS.Commands.EditFlat
{
    public class EditFlatCommand : FlatDto ,IRequest
    {
    }
}

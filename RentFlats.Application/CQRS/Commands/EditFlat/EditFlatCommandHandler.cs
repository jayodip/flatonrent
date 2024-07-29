using AutoMapper;
using MediatR;
using RentFlats.Application.ApplicationUser;
using RentFlats.Domain.Entities;
using RentFlats.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Application.CQRS.Commands.EditFlat
{

    public class EditFlatCommandHandler : IRequestHandler<EditFlatCommand>
    {
        private readonly IFlatRepository _flatRepository;
        private readonly IUserContext _userContext;

        public EditFlatCommandHandler(IFlatRepository flatRepository, IUserContext userContext)
        {
            _flatRepository = flatRepository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditFlatCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            
            var flat = await _flatRepository.GetById(request.Id);
            var isEditable = currentUser != null && (flat.CreatedById == currentUser.Id || currentUser.IsInRole("Moderator"));
            if(!isEditable)
            {
                return Unit.Value;
            }

            flat.Title = request.Title;
            flat.Description = request.Description;
            flat.Price = request.Price;
            flat.FlatArea = request.FlatArea;
            flat.Address.City = request.City;
            flat.Address.Street = request.Street;
            flat.Address.PostalCode = request.PostalCode;
            flat.Address.FlatNumber = request.FlatNumber;
            flat.ContactDetails.PhoneNumber = request.PhoneNumber;
            flat.ContactDetails.Email = request.Email;

            await _flatRepository.Save();
            return Unit.Value;         
        }
    }
}

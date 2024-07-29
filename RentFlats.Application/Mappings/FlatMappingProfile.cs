using AutoMapper;
using RentFlats.Application.ApplicationUser;
using RentFlats.Application.CQRS.Commands.EditFlat;
using RentFlats.Application.Dtos;
using RentFlats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Application.Mappings
{
    public class FlatMappingProfile : Profile
    {

        public FlatMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<Flat, FlatDto>()
            .ForMember(dto => dto.IsEditable, opt => opt.MapFrom
            (src => user != null && (src.CreatedById == user.Id || user.IsInRole("Moderator"))))
            .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
            .ForMember(dto => dto.Email, opt => opt.MapFrom(src => src.ContactDetails.Email))
            .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForMember(dto => dto.FlatNumber, opt => opt.MapFrom(src => src.Address.FlatNumber))
            .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode));


            CreateMap<FlatDto, Flat>()
                .ForMember(e => e.Address, opt => opt.MapFrom(src => new FlatAddress()
                {
                    City = src.City,
                    Street = src.Street,
                    PostalCode = src.PostalCode,
                    FlatNumber = src.FlatNumber
                }))
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new FlatContactDetails()
                {
                    PhoneNumber = src.PhoneNumber,
                    Email = src.Email
                }));


            CreateMap<FlatDto, EditFlatCommand>();
                

        }
    }
}

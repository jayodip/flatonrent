using FluentValidation;
using RentFlats.Application.CQRS.Commands.CreateFlat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Application.CQRS.Commands.EditFlat
{
    public class EditFlatValidator : AbstractValidator<EditFlatCommand>
    {
        public EditFlatValidator()
        {
            RuleFor(e => e.Title)
                .NotEmpty().WithMessage("Please enter title of your AD")
                .MinimumLength(2).WithMessage("Titile should have at least 2 characters")
                .MaximumLength(25).WithMessage("Title should have a maximum of 25 characters");

            RuleFor(e => e.Price)
                .NotEmpty().WithMessage("Please enter the price of your flat (per month)");

            RuleFor(e => e.City)
                .NotEmpty().WithMessage("Please enter name of your flat's city");

            RuleFor(e => e.PhoneNumber)
                .NotEmpty().WithMessage("Please enter your phone number")
                .MinimumLength(9).WithMessage("Phone Number should have at least 9 numbers")
                .MaximumLength(12).WithMessage("Phone Number should have a maximum of 12 Numbers");
        }
    }
}

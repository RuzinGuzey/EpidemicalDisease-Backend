using FluentValidation;

namespace EpidemicalDisease.Application.Features.Vaccines.Commands.Create
{
    public class CreateVaccineCommandValidator : AbstractValidator<CreateVaccineCommand>
    {
        public CreateVaccineCommandValidator()
        {
            RuleFor(p => p.VaccineDate)
                .GreaterThan(p => p.AppointmentDate).When(p => p.VaccineDate.HasValue);
        }
    }
}

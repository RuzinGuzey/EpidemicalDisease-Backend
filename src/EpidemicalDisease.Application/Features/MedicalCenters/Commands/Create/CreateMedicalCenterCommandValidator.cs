using FluentValidation;

namespace EpidemicalDisease.Application.Features.MedicalCenters.Commands.Create
{
    public class CreateMedicalCenterCommandValidator : AbstractValidator<CreateMedicalCenterCommand>
    {
        public CreateMedicalCenterCommandValidator()
        {
        }
    }
}

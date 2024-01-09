using EpidemicalDisease.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EpidemicalDisease.Application.Features.DiseaseAnalyzes.Commands.Create
{
    public class CreateDiseaseAnalysisCommandValidator : AbstractValidator<CreateDiseaseAnalysisCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateDiseaseAnalysisCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(p => p.MedicalCenterId)
                .MustAsync(HasMedicalCenter).WithMessage("Medical center not found.");
        }

        //Veritabanında Medical Center Var/Yok kontrolü
        private async Task<bool> HasMedicalCenter(int medicalCenterId, CancellationToken cancellationToken)
        {
            return await _context.MedicalCenters.AnyAsync(p => p.Id == medicalCenterId, cancellationToken);
        }
    }
}

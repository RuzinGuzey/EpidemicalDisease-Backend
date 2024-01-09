using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Domain.Entities;
using FluentValidation;
using MediatR;

namespace EpidemicalDisease.Application.Features.DiseaseAnalyzes.Commands.Create
{
    public class CreateDiseaseAnalysisCommand : IRequest<int>
    {

        public int MedicalCenterId { get; set; }
        public int PersonId { get; set; }
        public DateTime AnalysisAppointment { get; set; }
        public DateTime? AnalysisDate { get; set; }
        public bool AnalysisResult { get; set; }
        public string? Notes { get; set; }
    }
    public class CreateDiseaseAnalysisCommandHandler : IRequestHandler<CreateDiseaseAnalysisCommand, int>
    {
        private readonly IApplicationDbContext _context;

        private readonly IValidator<CreateDiseaseAnalysisCommand> _validator;

        public CreateDiseaseAnalysisCommandHandler(IApplicationDbContext context, IValidator<CreateDiseaseAnalysisCommand> validator)
        {
            _context = context;

            _validator = validator;
        }
        public async Task<int> Handle(CreateDiseaseAnalysisCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            if (!_context.Persons.Any(p => p.Id == request.PersonId))
            {
                throw new Exception("Kişi bulunamadı.");
            }

            var diseaseAnalysis = new DiseaseAnalysis
            {
                MedicalCenterId = request.MedicalCenterId,
                PersonId = request.PersonId,
                AnalysisAppointment = request.AnalysisAppointment,
                AnalysisDate = request.AnalysisDate,
                AnalysisResult = request.AnalysisResult,
                Notes = request.Notes,


            };
            _context.DiseaseAnalyzes.Add(diseaseAnalysis);
            await _context.SaveChangesAsync(cancellationToken);
            return diseaseAnalysis.Id;
        }
    }
}

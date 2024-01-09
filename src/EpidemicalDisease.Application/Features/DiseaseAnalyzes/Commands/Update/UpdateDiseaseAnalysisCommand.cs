using EpidemicalDisease.Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace EpidemicalDisease.Application.Features.DiseaseAnalyzes.Commands.Update
{
    public class UpdateDiseaseAnalysisCommand : IRequest
    {
        public int Id { get; set; }
        public int MedicalCenterId { get; set; }
        public int PersonId { get; set; }
        public DateTime AnalysisAppointment { get; set; }
        public DateTime? AnalysisDate { get; set; }
        public bool AnalysisResult { get; set; }
        public string? Notes { get; set; }
    }
    public class UpdateDiseaseAnalysisCommandHandler : IRequestHandler<UpdateDiseaseAnalysisCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IValidator<UpdateDiseaseAnalysisCommand> _validator;

        public UpdateDiseaseAnalysisCommandHandler(IApplicationDbContext context, IValidator<UpdateDiseaseAnalysisCommand> validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task<Unit> Handle(UpdateDiseaseAnalysisCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var diseaseAnalysis = await _context.DiseaseAnalyzes.FindAsync(new object?[] { request.Id }, cancellationToken);
            if (diseaseAnalysis == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }

            diseaseAnalysis.MedicalCenterId = request.MedicalCenterId;
            diseaseAnalysis.PersonId = request.PersonId;
            diseaseAnalysis.AnalysisAppointment = request.AnalysisAppointment;
            diseaseAnalysis.AnalysisDate = request.AnalysisDate;
            diseaseAnalysis.AnalysisResult = request.AnalysisResult;
            diseaseAnalysis.Notes = request.Notes;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

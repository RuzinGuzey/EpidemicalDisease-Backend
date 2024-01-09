using EpidemicalDisease.Application.Common.Interfaces;
using MediatR;

namespace EpidemicalDisease.Application.Features.DiseaseAnalyzes.Commands.Delete
{
    public class DeleteDiseaseAnalysisCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteDiseaseAnalysisCommandHandler : IRequestHandler<DeleteDiseaseAnalysisCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteDiseaseAnalysisCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteDiseaseAnalysisCommand request, CancellationToken cancellationToken)
        {
            var diseaseAnalysis = await _context.DiseaseAnalyzes
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (diseaseAnalysis == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            _context.DiseaseAnalyzes.Remove(diseaseAnalysis);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

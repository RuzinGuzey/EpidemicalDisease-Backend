using AutoMapper;
using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Application.Dtos;
using MediatR;

namespace EpidemicalDisease.Application.Features.DiseaseAnalyzes.Queries.GetDiseaseAnalysis
{
    public class GetDiseaseAnalysisQuery : IRequest<DiseaseAnalysisDto>
    {
        public int Id { get; set; }
    }
    public class GetDiseaseAnalysisQueryHandler : IRequestHandler<GetDiseaseAnalysisQuery, DiseaseAnalysisDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDiseaseAnalysisQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DiseaseAnalysisDto> Handle(GetDiseaseAnalysisQuery request, CancellationToken cancellationToken)
        {
            //var diseaseAnalysis = await _context.DiseaseAnalyzes
            //    .Include(p => p.MedicalCenter)
            //    .Include(p => p.Person)
            //    .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            var diseaseAnalysis = await _context.DiseaseAnalyzes.FindAsync(request.Id);
            if (diseaseAnalysis == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            return _mapper.Map<DiseaseAnalysisDto>(diseaseAnalysis);
        }
    }
}

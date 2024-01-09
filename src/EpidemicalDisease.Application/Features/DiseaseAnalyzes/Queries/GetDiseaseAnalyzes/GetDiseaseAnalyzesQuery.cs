using AutoMapper;
using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EpidemicalDisease.Application.Features.DiseaseAnalyzes.Queries.GetDiseaseAnalyzes
{
    public class GetDiseaseAnalyzesQuery : IRequest<List<DiseaseAnalysisDto>>
    {
    }
    public class GetDiseaseAnalyzesQueryHandler : IRequestHandler<GetDiseaseAnalyzesQuery, List<DiseaseAnalysisDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDiseaseAnalyzesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<DiseaseAnalysisDto>> Handle(GetDiseaseAnalyzesQuery request, CancellationToken cancellationToken)
        {
            var disesaseAnalyzes = await _context.DiseaseAnalyzes.ToListAsync(cancellationToken);
            return _mapper.Map<List<DiseaseAnalysisDto>>(disesaseAnalyzes);
        }
    }
}

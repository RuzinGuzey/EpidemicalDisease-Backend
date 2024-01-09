using AutoMapper;
using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EpidemicalDisease.Application.Features.MedicalCenters.Queries.GetMedicalCenters
{
    public class GetMedicalCentersQuery : IRequest<List<MedicalCenterDto>>
    {
        public class GetMedicalCentersQueryHandler : IRequestHandler<GetMedicalCentersQuery, List<MedicalCenterDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;


            public GetMedicalCentersQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<MedicalCenterDto>> Handle(GetMedicalCentersQuery request, CancellationToken cancellationToken)
            {
                var medicalCenters = await _context.MedicalCenters.ToListAsync(cancellationToken);
                return _mapper.Map<List<MedicalCenterDto>>(medicalCenters);

            }

        }
    }
}

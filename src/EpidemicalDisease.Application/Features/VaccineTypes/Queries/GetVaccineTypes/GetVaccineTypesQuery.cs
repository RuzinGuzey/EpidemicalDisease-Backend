using AutoMapper;
using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EpidemicalDisease.Application.Features.VaccineTypes.Queries.GetVaccineTypes
{
    public class GetVaccineTypesQuery : IRequest<List<VaccineTypeDto>>
    {
    }
    public class GetVaccineTypesQueryHandler : IRequestHandler<GetVaccineTypesQuery, List<VaccineTypeDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVaccineTypesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<VaccineTypeDto>> Handle(GetVaccineTypesQuery request, CancellationToken cancellationToken)
        {
            var vaccineType = await _context.VaccineTypes.ToListAsync(cancellationToken);
            return _mapper.Map<List<VaccineTypeDto>>(vaccineType);
        }

    }
}

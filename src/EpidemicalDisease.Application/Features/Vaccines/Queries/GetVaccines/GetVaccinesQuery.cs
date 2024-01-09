using AutoMapper;
using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EpidemicalDisease.Application.Features.Vaccines.Queries.GetVaccines
{
    public class GetVaccinesQuery : IRequest<List<VaccineDto>>
    {
    }
    public class GetVaccinesQueryHandler : IRequestHandler<GetVaccinesQuery, List<VaccineDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVaccinesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<VaccineDto>> Handle(GetVaccinesQuery request, CancellationToken cancellationToken)
        {
            var vaccine = await _context.Vaccines.ToListAsync(cancellationToken);
            return _mapper.Map<List<VaccineDto>>(vaccine);
        }

    }
}

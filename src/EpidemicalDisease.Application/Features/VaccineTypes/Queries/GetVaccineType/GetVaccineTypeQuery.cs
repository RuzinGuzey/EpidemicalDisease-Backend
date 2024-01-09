using AutoMapper;
using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Application.Dtos;
using MediatR;

namespace EpidemicalDisease.Application.Features.VaccineTypes.Queries.GetVaccineType
{
    public class GetVaccineTypeQuery : IRequest<VaccineTypeDto>
    {
        public int Id { get; set; }
    }
    public class GetVaccineTypeQueryHandler : IRequestHandler<GetVaccineTypeQuery, VaccineTypeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVaccineTypeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<VaccineTypeDto> Handle(GetVaccineTypeQuery request, CancellationToken cancellationToken)
        {
            var vaccineType = await _context.VaccineTypes.FindAsync(request.Id);
            if (vaccineType == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            return _mapper.Map<VaccineTypeDto>(vaccineType);
        }

    }

}

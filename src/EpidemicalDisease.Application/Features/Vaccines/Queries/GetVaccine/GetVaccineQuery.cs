using AutoMapper;
using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Application.Dtos;
using MediatR;

namespace EpidemicalDisease.Application.Features.Vaccines.Queries.GetVaccine
{
    public class GetVaccineQuery : IRequest<VaccineDto>
    {
        public int Id { get; set; }
    }
    public class GetVaccineQueryHandler : IRequestHandler<GetVaccineQuery, VaccineDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVaccineQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<VaccineDto> Handle(GetVaccineQuery request, CancellationToken cancellationToken)
        {
            var vaccine = await _context.Vaccines.FindAsync(request.Id);
            if (vaccine == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            return _mapper.Map<VaccineDto>(vaccine);
        }
    }
}

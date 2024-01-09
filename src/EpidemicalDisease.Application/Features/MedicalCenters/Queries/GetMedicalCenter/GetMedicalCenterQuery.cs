using AutoMapper;
using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Application.Dtos;
using MediatR;

namespace EpidemicalDisease.Application.Features.MedicalCenters.Queries.GetMedicalCenter
{
    public class GetMedicalCenterQuery : IRequest<MedicalCenterDto>
    {
        public int Id { get; set; }
    }
    public class GetMedicalCenterQueryHandler : IRequestHandler<GetMedicalCenterQuery, MedicalCenterDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMedicalCenterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        async Task<MedicalCenterDto> IRequestHandler<GetMedicalCenterQuery, MedicalCenterDto>.Handle(GetMedicalCenterQuery request, CancellationToken cancellationToken)
        {
            var medicalCenter = await _context.MedicalCenters.FindAsync(request.Id);
            if (medicalCenter == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            return _mapper.Map<MedicalCenterDto>(medicalCenter);
        }
    }
}

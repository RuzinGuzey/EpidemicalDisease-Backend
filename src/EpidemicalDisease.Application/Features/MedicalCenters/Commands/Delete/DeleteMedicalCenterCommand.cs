using EpidemicalDisease.Application.Common.Interfaces;
using MediatR;

namespace EpidemicalDisease.Application.Features.MedicalCenters.Commands.Delete
{
    public class DeleteMedicalCenterCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteMedicalCenterCommandHandler : IRequestHandler<DeleteMedicalCenterCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMedicalCenterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteMedicalCenterCommand request, CancellationToken cancellationToken)
        {
            var medicalCenter = await _context.MedicalCenters.FindAsync(request.Id);
            if (medicalCenter == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            _context.MedicalCenters.Remove(medicalCenter);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}

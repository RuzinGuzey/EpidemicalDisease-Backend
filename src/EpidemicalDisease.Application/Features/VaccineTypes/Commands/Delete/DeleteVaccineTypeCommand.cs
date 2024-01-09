using EpidemicalDisease.Application.Common.Interfaces;
using MediatR;

namespace EpidemicalDisease.Application.Features.VaccineTypes.Commands.Delete
{
    public class DeleteVaccineTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteVaccineTypeCommandHandler : IRequestHandler<DeleteVaccineTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteVaccineTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteVaccineTypeCommand request, CancellationToken cancellationToken)
        {
            var vaccineType = await _context.VaccineTypes.FindAsync(request.Id);
            if (vaccineType == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            _context.VaccineTypes.Remove(vaccineType);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}

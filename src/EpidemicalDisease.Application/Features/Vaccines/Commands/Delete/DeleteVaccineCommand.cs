using EpidemicalDisease.Application.Common.Interfaces;
using MediatR;

namespace EpidemicalDisease.Application.Features.Vaccines.Commands.Delete
{
    public class DeleteVaccineCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteVaccineCommandHandler : IRequestHandler<DeleteVaccineCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteVaccineCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteVaccineCommand request, CancellationToken cancellationToken)
        {
            var vaccine = await _context.Vaccines.FindAsync(request.Id);
            if (vaccine == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            _context.Vaccines.Remove(vaccine);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}

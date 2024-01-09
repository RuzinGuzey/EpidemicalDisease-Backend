using EpidemicalDisease.Application.Common.Interfaces;
using MediatR;


namespace EpidemicalDisease.Application.Features.Persons.Commands.Delete
{
    public class DeletePersonCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePersonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _context.Persons.FindAsync(request.Id);
            if (person == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}

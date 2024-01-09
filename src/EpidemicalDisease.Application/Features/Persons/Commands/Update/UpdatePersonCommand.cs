using EpidemicalDisease.Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace EpidemicalDisease.Application.Features.Persons.Commands.Update
{
    public class UpdatePersonCommand : IRequest
    {
        public int Id { get; set; }
        public int TC { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
    }
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IValidator<UpdatePersonCommand> _validator;

        public UpdatePersonCommandHandler(IApplicationDbContext context, IValidator<UpdatePersonCommand> validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var person = await _context.Persons.FindAsync(request.Id);
            if (person == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }

            person.TC = request.TC;
            person.FirstName = request.FirstName;
            person.SurName = request.SurName;
            person.City = request.City;
            person.Region = request.Region;


            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}

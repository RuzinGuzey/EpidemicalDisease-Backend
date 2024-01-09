using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Domain.Entities;
using FluentValidation;
using MediatR;

namespace EpidemicalDisease.Application.Features.Persons.Commands.Create
{
    public class CreatePersonCommand : IRequest<int>
    {

        public int TC { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
    }
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IApplicationDbContext _context;

        private readonly IValidator<CreatePersonCommand> _validator;

        public CreatePersonCommandHandler(IApplicationDbContext context, IValidator<CreatePersonCommand> validator)
        {
            _context = context;

            _validator = validator;
        }
        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var person = new Person
            {

                TC = request.TC,
                FirstName = request.FirstName,
                SurName = request.SurName,
                City = request.City,
                Region = request.Region,


            };
            _context.Persons.Add(person);
            await _context.SaveChangesAsync(cancellationToken);
            return person.Id;
        }
    }
}

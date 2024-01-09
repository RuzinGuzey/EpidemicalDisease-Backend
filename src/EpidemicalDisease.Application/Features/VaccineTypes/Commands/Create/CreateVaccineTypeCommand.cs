using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Domain.Entities;
using FluentValidation;
using MediatR;


namespace EpidemicalDisease.Application.Features.VaccineTypes.Commands.Create
{
    public class CreateVaccineTypeCommand : IRequest<int>
    {

        public string Name { get; set; } = string.Empty;

    }
    public class CreateVaccineTypeCommandHandler : IRequestHandler<CreateVaccineTypeCommand, int>
    {
        private readonly IApplicationDbContext _context;

        private readonly IValidator<CreateVaccineTypeCommand> _validator;

        public CreateVaccineTypeCommandHandler(IApplicationDbContext context, IValidator<CreateVaccineTypeCommand> validator)
        {
            _context = context;

            _validator = validator;
        }
        public async Task<int> Handle(CreateVaccineTypeCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var vaccineType = new VaccineType
            {
                Name = request.Name,



            };

            _context.VaccineTypes.Add(vaccineType);
            await _context.SaveChangesAsync(cancellationToken);
            return vaccineType.Id;
        }
    }
}

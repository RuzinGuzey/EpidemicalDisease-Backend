using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Domain.Entities;
using FluentValidation;
using MediatR;

namespace EpidemicalDisease.Application.Features.MedicalCenters.Commands.Create
{
    public class CreateMedicalCenterCommand : IRequest<int>
    {

        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;

    }
    public class CreateMedicalCenterCommandHandler : IRequestHandler<CreateMedicalCenterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        private readonly IValidator<CreateMedicalCenterCommand> _validator;

        public CreateMedicalCenterCommandHandler(IApplicationDbContext context, IValidator<CreateMedicalCenterCommand> validator)
        {
            _context = context;

            _validator = validator;
        }
        public async Task<int> Handle(CreateMedicalCenterCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var medicalCenter = new MedicalCenter
            {

                Code = request.Code,
                Name = request.Name,
                City = request.City,
                Region = request.Region,

            };
            _context.MedicalCenters.Add(medicalCenter);
            await _context.SaveChangesAsync(cancellationToken);
            return medicalCenter.Id;
        }
    }
}

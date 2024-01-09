using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Domain.Entities;
using FluentValidation;
using MediatR;

namespace EpidemicalDisease.Application.Features.Vaccines.Commands.Create
{
    public class CreateVaccineCommand : IRequest<int>
    {

        public int MedicalCenterId { get; set; }
        public int VaccineTypeId { get; set; }
        public int PersonId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime? VaccineDate { get; set; }
        public string? Notes { get; set; }
    }
    public class CreateVaccineCommandHandler : IRequestHandler<CreateVaccineCommand, int>
    {
        private readonly IApplicationDbContext _context;

        private readonly IValidator<CreateVaccineCommand> _validator;

        public CreateVaccineCommandHandler(IApplicationDbContext context, IValidator<CreateVaccineCommand> validator)
        {
            _context = context;

            _validator = validator;
        }
        public async Task<int> Handle(CreateVaccineCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var vaccine = new Vaccine
            {

                MedicalCenterId = request.MedicalCenterId,
                VaccineTypeId = request.VaccineTypeId,
                PersonId = request.PersonId,
                AppointmentDate = request.AppointmentDate,
                VaccineDate = request.VaccineDate,
                Notes = request.Notes,
            };
            _context.Vaccines.Add(vaccine);
            await _context.SaveChangesAsync(cancellationToken);
            return vaccine.Id;
        }
    }

}

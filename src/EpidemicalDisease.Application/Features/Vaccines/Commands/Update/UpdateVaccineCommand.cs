using EpidemicalDisease.Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace EpidemicalDisease.Application.Features.Vaccines.Commands.Update
{
    public class UpdateVaccineCommand : IRequest
    {
        public int Id { get; set; }
        public int MedicalCenterId { get; set; }
        public int VaccineTypeId { get; set; }
        public int PersonId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime? VaccineDate { get; set; }
        public string? Notes { get; set; }
    }
    public class UpdateVaccineCommandHandler : IRequestHandler<UpdateVaccineCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IValidator<UpdateVaccineCommand> _validator;

        public UpdateVaccineCommandHandler(IApplicationDbContext context, IValidator<UpdateVaccineCommand> validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task<Unit> Handle(UpdateVaccineCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var vaccine = await _context.Vaccines.FindAsync(request.Id);
            if (vaccine == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }

            vaccine.MedicalCenterId = request.MedicalCenterId;
            vaccine.VaccineTypeId = request.VaccineTypeId;
            vaccine.PersonId = request.PersonId;
            vaccine.AppointmentDate = request.AppointmentDate;
            vaccine.VaccineDate = request.VaccineDate;
            vaccine.Notes = request.Notes;


            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}

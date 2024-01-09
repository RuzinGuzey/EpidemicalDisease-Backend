using EpidemicalDisease.Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace EpidemicalDisease.Application.Features.VaccineTypes.Commands.Update
{
    public class UpdateVaccineTypeCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MedicalCenterId { get; set; }

    }
    public class UpdateVaccineTypeCommandHandler : IRequestHandler<UpdateVaccineTypeCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IValidator<UpdateVaccineTypeCommand> _validator;

        public UpdateVaccineTypeCommandHandler(IApplicationDbContext context, IValidator<UpdateVaccineTypeCommand> validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task<Unit> Handle(UpdateVaccineTypeCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var vaccineType = await _context.VaccineTypes.FindAsync(request.Id);
            if (vaccineType == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }

            vaccineType.Name = request.Name;



            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}

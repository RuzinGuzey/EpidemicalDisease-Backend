using EpidemicalDisease.Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace EpidemicalDisease.Application.Features.MedicalCenters.Commands.Update
{
    public class UpdateMedicalCenterCommand : IRequest
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
    }
    public class UpdateMedicalCenterCommandHandler : IRequestHandler<UpdateMedicalCenterCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IValidator<UpdateMedicalCenterCommand> _validator;

        public UpdateMedicalCenterCommandHandler(IApplicationDbContext context, IValidator<UpdateMedicalCenterCommand> validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task<Unit> Handle(UpdateMedicalCenterCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var medicalCenter = await _context.MedicalCenters.FindAsync(request.Id);
            if (medicalCenter == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }

            medicalCenter.Code = request.Code;
            medicalCenter.Name = request.Name;
            medicalCenter.City = request.City;
            medicalCenter.Region = request.Region;


            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}

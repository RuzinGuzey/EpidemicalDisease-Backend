using AutoMapper;
using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Application.Dtos;
using MediatR;

namespace EpidemicalDisease.Application.Features.Persons.Queries.GetPerson
{
    public class GetPersonQuery : IRequest<PersonDto>
    {
        public int Id { get; set; }
    }
    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PersonDto> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await _context.Persons.FindAsync(request.Id);
            if (person == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            return _mapper.Map<PersonDto>(person);
        }

    }
}

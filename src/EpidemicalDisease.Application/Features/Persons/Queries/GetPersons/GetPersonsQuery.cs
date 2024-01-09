using AutoMapper;
using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EpidemicalDisease.Application.Features.Persons.Queries.GetPersons
{
    public class GetPersonsQuery : IRequest<List<PersonDto>>
    {
    }
    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, List<PersonDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<PersonDto>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            var person = await _context.Persons.ToListAsync(cancellationToken);
            return _mapper.Map<List<PersonDto>>(person);
        }


    }
}

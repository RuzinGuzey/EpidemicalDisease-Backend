using EpidemicalDisease.Application.Features.Persons.Commands.Create;
using EpidemicalDisease.Application.Features.Persons.Commands.Delete;
using EpidemicalDisease.Application.Features.Persons.Commands.Update;
using EpidemicalDisease.Application.Features.Persons.Queries.GetPerson;
using EpidemicalDisease.Application.Features.Persons.Queries.GetPersons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EpidemicalDisease.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetPersonsQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetPersonQuery() { Id = id }));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePersonCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePersonCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeletePersonCommand() { Id = id });
            return Ok();
        }
    }
}


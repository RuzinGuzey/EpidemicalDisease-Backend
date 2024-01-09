using EpidemicalDisease.Application.Features.VaccineTypes.Commands.Create;
using EpidemicalDisease.Application.Features.VaccineTypes.Commands.Delete;
using EpidemicalDisease.Application.Features.VaccineTypes.Commands.Update;
using EpidemicalDisease.Application.Features.VaccineTypes.Queries.GetVaccineType;
using EpidemicalDisease.Application.Features.VaccineTypes.Queries.GetVaccineTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EpidemicalDisease.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VaccineTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetVaccineTypesQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetVaccineTypeQuery() { Id = id }));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateVaccineTypeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateVaccineTypeCommand command)
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
            await _mediator.Send(new DeleteVaccineTypeCommand() { Id = id });
            return Ok();
        }

    }
}

using EpidemicalDisease.Application.Features.Vaccines.Commands.Create;
using EpidemicalDisease.Application.Features.Vaccines.Commands.Delete;
using EpidemicalDisease.Application.Features.Vaccines.Commands.Update;
using EpidemicalDisease.Application.Features.Vaccines.Queries.GetVaccine;
using EpidemicalDisease.Application.Features.Vaccines.Queries.GetVaccines;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EpidemicalDisease.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VaccinesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetVaccinesQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetVaccineQuery() { Id = id }));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateVaccineCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateVaccineCommand command)
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
            await _mediator.Send(new DeleteVaccineCommand() { Id = id });
            return Ok();
        }

    }
}

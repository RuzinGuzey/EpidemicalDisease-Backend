using EpidemicalDisease.Application.Features.MedicalCenters.Commands.Create;
using EpidemicalDisease.Application.Features.MedicalCenters.Commands.Delete;
using EpidemicalDisease.Application.Features.MedicalCenters.Commands.Update;
using EpidemicalDisease.Application.Features.MedicalCenters.Queries.GetMedicalCenter;
using EpidemicalDisease.Application.Features.MedicalCenters.Queries.GetMedicalCenters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EpidemicalDisease.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalCentersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicalCentersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetMedicalCentersQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetMedicalCenterQuery() { Id = id }));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMedicalCenterCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateMedicalCenterCommand command)
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
            await _mediator.Send(new DeleteMedicalCenterCommand() { Id = id });
            return Ok();
        }
    }
}


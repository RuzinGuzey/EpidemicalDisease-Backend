using EpidemicalDisease.Application.Features.DiseaseAnalyzes.Commands.Create;
using EpidemicalDisease.Application.Features.DiseaseAnalyzes.Commands.Delete;
using EpidemicalDisease.Application.Features.DiseaseAnalyzes.Commands.Update;
using EpidemicalDisease.Application.Features.DiseaseAnalyzes.Queries.GetDiseaseAnalysis;
using EpidemicalDisease.Application.Features.DiseaseAnalyzes.Queries.GetDiseaseAnalyzes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EpidemicalDisease.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseAnalyzesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiseaseAnalyzesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetDiseaseAnalyzesQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetDiseaseAnalysisQuery() { Id = id }));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDiseaseAnalysisCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateDiseaseAnalysisCommand command)
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
            await _mediator.Send(new DeleteDiseaseAnalysisCommand() { Id = id });
            return Ok();
        }
    }
}


using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerticalSliceHeroApi.Features.Heroes.Command;
using VerticalSliceHeroApi.Features.Heroes.Query;

namespace VerticalSliceHeroApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<HeroController> _logger;

        public HeroController(IMediator mediator, ILogger<HeroController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("/heroes")]
        public async Task<ActionResult> GetHeroes(string? Name = null)
        {
            try
            {
                var query = new GetHeroesQuery();
                query.Name = Name;
                var result = await _mediator.Send(query);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("/heroes/{Id}")]
        public async Task<ActionResult> GetHero(string Id)
        {
            try
            {
                var query = new GetHeroQuery();
                query.Id = Id;
                var result = await _mediator.Send(query);
                if (result == null)
                {
                    return NotFound("Hero not found.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("/heroes")]
        public async Task<ActionResult> AddHero(AddHeroCommand hero)
        {
            try
            {
                var result = await _mediator.Send(hero);
                if (result == null)
                {
                    return BadRequest("failed to add hero.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("/heroes/{Id}")]
        public async Task<ActionResult> UpdateHero(string Id, UpdateHeroCommand hero)
        {
            try
            {
                if (hero == null || Id != hero.Id)
                {
                    return BadRequest();
                }
                await _mediator.Send(hero);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("/heroes/{Id}")]
        public async Task<ActionResult> DeleteHero(string Id)
        {
            try
            {
                await _mediator.Send(new DeleteHeroCommand
                {
                    Id = Id
                });
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }
    }
}
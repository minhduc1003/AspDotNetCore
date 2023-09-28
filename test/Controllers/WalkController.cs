using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Models.Domain;
using test.Models.Dto;
using test.Repositories;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkReposities walkReposities;

        public WalkController(IMapper mapper,IWalkReposities walkReposities)
        {
            this.mapper = mapper;
            this.walkReposities = walkReposities;
        }
        [HttpPost]
        public async Task<IActionResult> PostWalk([FromBody] WalkActionDto walkActionDto)
        {
            var walker = mapper.Map<Walks>(walkActionDto);
            await walkReposities.create(walker);
            var walkerDto = mapper.Map<WalkDto>(walker);
            return Ok(walkerDto);
        }
        [HttpGet]
        public async Task<IActionResult> getAllWalk([FromQuery] string? FilterName, [FromQuery] string? FilterString, [FromQuery] string? sortBy, [FromQuery]bool isAsc, [FromQuery] int pageNumber, [FromQuery] int pageSize )
        {
            var walker = await walkReposities.get(FilterName, FilterString,sortBy,isAsc,pageNumber,pageSize);
            var walkerDto = mapper.Map<List<WalkDto>>(walker);

            return Ok(walkerDto);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            var walker = await walkReposities.getById(id);
            if(walker == null)
            {
              return NotFound(id);
            }
            var walkerDto = mapper.Map<WalkDto>(walker);
            return Ok(walkerDto);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateById([FromRoute] Guid id,[FromBody] WalkActionDto walkActionDto)
        {
            var warker = mapper.Map<Walks>(walkActionDto);
            var warkerAfterChange = await walkReposities.update(warker, id);
            if(warkerAfterChange == null)
            {
                return NotFound();
            }
            var warkerDto = mapper.Map<WalkDto>(warkerAfterChange);
            return Ok(warkerDto);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> deleteById([FromRoute] Guid id)
        {
            var warker = await walkReposities.getById(id);
            if (warker == null)
            {
                return NotFound();
            }
            var res = await walkReposities.delete(warker);
            return Ok(res);

        }
    }
}

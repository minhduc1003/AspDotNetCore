using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Custom;
using test.data;
using test.Models.Domain;
using test.Models.Dto;
using test.Repositories;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly WalkDbContext dbContext;
        private readonly IRegionRepositories regionRepositries;
        private readonly IMapper mapper;

        public RegionsController(WalkDbContext dbContext, IRegionRepositories regionRepositries,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepositries = regionRepositries;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> getAllRegions()
        {
            var regions = await regionRepositries.GetRegionsAsync();
            /*    List<RegionsDto> regionsDto = new List<RegionsDto>();
               foreach (var region in regions)
               {
                   regionsDto.Add(new RegionsDto()
                   {
                       Name = region.Name,
                       Code = region.Code,
                       Id = region.Id,
                       RegionImageUrl = region.RegionImageUrl,

                   });
               }*/
            var regionsDto = mapper.Map<List<RegionsDto>>(regions);
            return Ok(regionsDto);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getRegionsById([FromRoute] Guid id)
        {
           var region = await regionRepositries.GetById(id);
            if(region == null)
            {
                return NotFound();
            }
/*            var regionDto = new RegionsDto()
            {
                Name = region.Name,
                Code = region.Code,
                Id = region.Id,
                RegionImageUrl = region.RegionImageUrl,
            };*/
            var regionDto = mapper.Map<RegionsDto>(region); 
            return Ok(regionDto);
        }
        [HttpPost]
        [Custom]
        public async Task<IActionResult> postRegion([FromBody] RegionActionDto RegionActionDto)
        {
            
                var regionDomainModel = new Regions()
                {
                    Name = RegionActionDto.Name,
                    Code = RegionActionDto.Code,
                    RegionImageUrl = RegionActionDto.RegionImageUrl,
                };
                regionDomainModel = await regionRepositries.Create(regionDomainModel);
                /*            var regionDto = new RegionsDto()
                            {
                                Id = regionDomainModel.Id,
                                Name = regionDomainModel.Name,
                                Code = regionDomainModel.Code,
                                RegionImageUrl = regionDomainModel.RegionImageUrl,
                            };*/
                var regionDto = mapper.Map<RegionsDto>(regionDomainModel);
                return CreatedAtAction(nameof(getRegionsById), new { id = regionDto.Id }, regionDto);
           
           
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdatetRegionById([FromRoute] Guid id, [FromBody] RegionActionDto regionActionDto)
        {
            var regionDomainModel = await regionRepositries.GetById(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            regionDomainModel.Code = regionActionDto.Code;
            regionDomainModel.Name = regionActionDto.Name;
            regionDomainModel.RegionImageUrl = regionActionDto.RegionImageUrl;
           await dbContext.SaveChangesAsync();
            /*   var regionDto = new RegionsDto()
               {
                   Id = regionDomainModel.Id,
                   Name = regionDomainModel.Name,
                   Code = regionDomainModel.Code,
                   RegionImageUrl = regionDomainModel.RegionImageUrl,
               };*/
            var regionDto = mapper.Map<RegionsDto>(regionDomainModel);
            return Ok(regionDto);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegionById([FromRoute] Guid id)
        {

            var regionDomainModel = await regionRepositries.GetById(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            regionDomainModel = await regionRepositries.Delete(regionDomainModel);
            /*            var regionDto = new RegionsDto()
                        {
                            Id = regionDomainModel.Id,
                            Name = regionDomainModel.Name,
                            Code = regionDomainModel.Code,
                            RegionImageUrl = regionDomainModel.RegionImageUrl,
                        };*/
            var regionDto = mapper.Map<RegionsDto>(regionDomainModel);
            return Ok(regionDto);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repo;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("region-api")]
    public class RegionController : Controller
    {
        public IRegionRepo IRegionRepo { get; }
        public IMapper IMapper { get; }

        public RegionController(IRegionRepo _iRegionRepo, IMapper _iMapper)
        {
            IRegionRepo = _iRegionRepo;
            IMapper = _iMapper;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAllRegions()
        {
            var region = this.IRegionRepo.GetAll();
            var regiondto = IMapper.Map<List<Models.DTO.Regiondto>>(region);

            return Ok(regiondto);
        }

        [HttpGet]
        [Route("getallasync")]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var region = await this.IRegionRepo.GetAllAsync();
            var regiondto = IMapper.Map<List<Models.DTO.Regiondto>>(region);

            return Ok(regiondto);
        }

        [HttpGet]
        [ActionName("GetRegionsAsync")]
        [Route("getasync/{id}")]
        public async Task<IActionResult> GetRegionsAsync(Guid id)
        {
            var region = await this.IRegionRepo.GetById(id);
            if (region == null)
            {
                return NotFound();
            }
            var regiondto = IMapper.Map<Models.DTO.Regiondto>(region);

            return Ok(regiondto);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionsAsync(AddRegionRequest _addregionrequest)
        {
            var region = new Region()
            {
                Code = _addregionrequest.RCode,
                Area = _addregionrequest.RArea,
                Lat = _addregionrequest.RLat,
                Long = _addregionrequest.RLong,
                Name = _addregionrequest.RName,
                Population = _addregionrequest.RPopulation
            };

            region = await this.IRegionRepo.AddAsync(region);

            var regiondto = new Regiondto()
            {
                RCode = region.Code,
                RArea = region.Area,
                RLat = region.Lat,
                RLong = region.Long,
                RName = region.Name,
                RPopulation = region.Population
            };

            return CreatedAtAction(nameof(GetRegionsAsync), new { id = region.Id }, regiondto);
        }

        [HttpDelete]
        [Route("delete/{id:guid}")]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            var region = await this.IRegionRepo.DeleteById(id);

            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);
        }

        [HttpPut]
        [Route("update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] AddRegionRequest _regionreq)
        {
            var region = new Region()
            {
                Code = _regionreq.RCode,
                Area = _regionreq.RArea,
                Name = _regionreq.RName,
                Lat = _regionreq.RLat,
                Long = _regionreq.RLong,
                Population = _regionreq.RPopulation
            };

            var updatedregion = await this.IRegionRepo.Update(id, region);

            if (updatedregion == null)
            {
                return NotFound();
            }
            return Ok(updatedregion);
        }
    }
}

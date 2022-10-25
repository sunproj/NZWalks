using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    }
}

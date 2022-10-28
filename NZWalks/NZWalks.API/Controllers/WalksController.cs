using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repo;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("walks")]
    public class WalksController : Controller
    {
        private readonly IWalkRepo iWalksRepo;
        private readonly IMapper IMapper;

        public WalksController(IWalkRepo _iWalksRepo, IMapper _iMapper)
        {
            iWalksRepo = _iWalksRepo;
            IMapper = _iMapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var walk = await this.iWalksRepo.GetAllAsync();

            var walkdto = IMapper.Map<List<Models.DTO.Walkdto>>(walk);

            return Ok(walkdto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id:Guid}")]
        public async Task<IActionResult> GetAllWalksAsync(Guid id)
        {
            var walk = await this.iWalksRepo.GetByIdAsync(id);

            var walkdto = IMapper.Map<Models.DTO.Walkdto>(walk);

            return Ok(walkdto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_walkRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddWalksAsync(WalkRequest _walkRequest)
        {
            // Convert DTO to domain object
            var walk = new Walk()
            {
                Name = _walkRequest.Name,
                Length = _walkRequest.Length,
                RegionId = _walkRequest.RegionId,
                WalkDifficultyId = _walkRequest.WalkDifficultyId
            };

            walk = await this.iWalksRepo.AddWalkAsync(walk);

            // Concert back to DTO

            var walkdto = IMapper.Map<Models.Domain.Walk>(walk);

            return Ok(walkdto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_walkreq"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] WalkRequest _walkreq)
        {
            var walk = new Walk()
            {
                Name = _walkreq.Name,
                Length = _walkreq.Length,
                RegionId = _walkreq.RegionId,
                WalkDifficultyId = _walkreq.WalkDifficultyId
            };

            var updated_walk = await this.iWalksRepo.Update(id, walk);

            if (updated_walk == null)
            {
                return NotFound();
            }
            return Ok(updated_walk);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id:guid}")]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            var walk = await this.iWalksRepo.Delete(id);

            if (walk == null)
            {
                return NotFound();
            }
            return Ok(walk);
        }
    }
}

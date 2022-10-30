using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repo;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("walksdifficulty")]
    public class WalksDifficultyController : Controller
    {
        private readonly IWalksDifficultyRepo iWalksDifficultyRepo;
        private readonly IMapper imapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_iWalksDifficultyRepo"></param>
        /// <param name="_imapper"></param>
        public WalksDifficultyController(IWalksDifficultyRepo _iWalksDifficultyRepo, IMapper _imapper)
        {
            iWalksDifficultyRepo = _iWalksDifficultyRepo;
            imapper = _imapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var walkDifficulty = await iWalksDifficultyRepo.GetAllWalksDifficulty();

            var walkDifficultydto = imapper.Map<List<Models.DTO.WalkDifficultydto>>(walkDifficulty);

            return Ok(walkDifficultydto);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var walkDifficulty = await iWalksDifficultyRepo.GetByIdlWalksDifficulty(id);

            var walkDifficultydto = imapper.Map<Models.DTO.WalkDifficultydto>(walkDifficulty);

            if (walkDifficultydto != null)
            {
                return Ok(walkDifficultydto);
            }
            else
            {
                return NotFound(walkDifficultydto);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_walkDifficultydto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(WalkDifficultydto _walkDifficultydto)
        {
            var walkDifficulty = await iWalksDifficultyRepo.AddWalksDifficulty(_walkDifficultydto);

            var walkDifficultydto = imapper.Map<Models.DTO.WalkDifficultydto>(walkDifficulty);

            if (walkDifficultydto != null)
            {
                return Ok(walkDifficultydto);
            }
            else
            {
                return NotFound(walkDifficultydto);
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_walkDifficultydto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update/{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id , [FromBody] WalkDifficultydto _walkDifficultydto)
        {
            var walkDifficulty = await iWalksDifficultyRepo.UpdateWalksDifficulty(id, _walkDifficultydto);

            var walkDifficultydto = imapper.Map<Models.DTO.WalkDifficultydto>(walkDifficulty);

            if (walkDifficultydto != null)
            {
                return Ok(walkDifficultydto);
            }
            else
            {
                return NotFound(walkDifficultydto);
            }

        }

        [HttpDelete]
        [Route("delete/{id:Guid}")]
        public async Task<IActionResult> DeleteWalkDifficulty(Guid id)
        {
            var walkDifficulty = await iWalksDifficultyRepo.DeleteWalksDifficulty(id);

            var walkDifficultydto = imapper.Map<Models.DTO.WalkDifficultydto>(walkDifficulty);

            if (walkDifficultydto != null)
            {
                return Ok(walkDifficultydto);
            }
            else
            {
                return NotFound(walkDifficultydto);
            }

        }
    }
}

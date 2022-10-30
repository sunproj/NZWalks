using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repo
{
    public interface IWalksDifficultyRepo
    {
        // GetAll Walks Difficulty

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<WalkDifficulty>> GetAllWalksDifficulty();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<WalkDifficulty> GetByIdlWalksDifficulty(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_walkDifficultydto"></param>
        /// <returns></returns>
        Task<WalkDifficulty> AddWalksDifficulty(WalkDifficultydto _walkDifficultydto);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="walkDifficultydto"></param>
        /// <returns></returns>
        Task<WalkDifficulty> UpdateWalksDifficulty(Guid id, WalkDifficultydto walkDifficultydto);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WalkDifficulty> DeleteWalksDifficulty(Guid id);
    }
}

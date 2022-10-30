using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repo
{
    public class WalksDifficultyRepo : IWalksDifficultyRepo
    {
        private readonly dbContext dbContext;

        public WalksDifficultyRepo(dbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<WalkDifficulty>> GetAllWalksDifficulty()
        {
            return await dbContext.WalkDifficulty.ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WalkDifficulty> GetByIdlWalksDifficulty(Guid id)
        {
            return await dbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.WalkDifficultyId == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_walkDifficultydto"></param>
        /// <returns></returns>
        public async Task<WalkDifficulty> AddWalksDifficulty(WalkDifficultydto _walkDifficultydto)
        {
            var WalkDifficulty = new WalkDifficulty()
            {
                WalkDifficultyId = new Guid(),
                Code = _walkDifficultydto.Code
            };

            await dbContext.WalkDifficulty.AddAsync(WalkDifficulty);
            await dbContext.SaveChangesAsync();
            return WalkDifficulty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="walkDifficultydto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<WalkDifficulty> UpdateWalksDifficulty(Guid id, WalkDifficultydto walkDifficultydto)
        {
            var walkDifficulty = dbContext.WalkDifficulty.FirstOrDefault(x => x.WalkDifficultyId == id);

            if (walkDifficulty != null)
            {
                walkDifficulty = new WalkDifficulty()
                { 
                    WalkDifficultyId= id,
                    Code = walkDifficultydto.Code
                };

                await dbContext.SaveChangesAsync();

                
            }
            return walkDifficulty;
        }


        public async Task<WalkDifficulty> DeleteWalksDifficulty(Guid id)
        {
            var walkDifficulty = dbContext.WalkDifficulty.FirstOrDefault(x => x.WalkDifficultyId == id);

            if (walkDifficulty != null)
            {
                dbContext.WalkDifficulty.Remove(walkDifficulty);
                await dbContext.SaveChangesAsync();


            }
            return walkDifficulty;
        }
    }
}

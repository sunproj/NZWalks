using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repo
{
    public class WalkRepo : IWalkRepo
    {
        private readonly dbContext dbContext;

        public WalkRepo(dbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await dbContext.Walks
                .Include(x=>x.Region)
                .Include(x=>x.WalkDifficulty)
                .ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  async Task<Walk> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
                
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="walk"></param>
        /// <returns></returns>
        public async Task<Walk> AddWalkAsync(Walk walk)
        {
            walk.Id = new Guid();
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();

            return walk;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_walk"></param>
        /// <returns></returns>
        public async Task<Walk> Update(Guid id, Walk _walk)
        {
            var exiting_walk = await this.dbContext.Walks.FindAsync(id);
            if (exiting_walk != null)
            {
                exiting_walk.Name = _walk.Name;
                exiting_walk.Length = _walk.Length;
                exiting_walk.RegionId = _walk.RegionId;
                exiting_walk.WalkDifficultyId = _walk.WalkDifficultyId;

                await this.dbContext.SaveChangesAsync();
            }
            return exiting_walk;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Walk> Delete(Guid id)
        {
            var walk = await this.dbContext.Walks.FindAsync(id);

            if (walk != null)
            {
                this.dbContext.Walks.Remove(walk);
                await this.dbContext.SaveChangesAsync();
            }
            return walk;
        }
    }
}

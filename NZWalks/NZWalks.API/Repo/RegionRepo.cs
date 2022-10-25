using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repo
{
    public class RegionRepo : IRegionRepo
    {
        public dbContext DbContext { get; }
        public RegionRepo(dbContext _dbContext)
        {
            DbContext = _dbContext;
        }

        

        public IEnumerable<Region> GetAll()
        {
            return this.DbContext.Regions.ToList();
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await this.DbContext.Regions.ToListAsync();
        }
    }
}

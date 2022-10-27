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

        public async Task<Region> GetById(Guid id)
        {
            var region = this.DbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
#pragma warning disable CS8603 // Possible null reference return.
            return await region;
#pragma warning restore CS8603 // Possible null reference return.

        }

        public async Task<Region> AddAsync(Region _region)
        {
            _region.Id = new Guid();
            await this.DbContext.Regions.AddAsync(_region);
            await this.DbContext.SaveChangesAsync();
            return _region;
        }

        public async Task<Region> DeleteById(Guid id)
        {
            var region = await this.DbContext.Regions.FindAsync(id);
            if (region != null)
            {
                this.DbContext.Regions.Remove(region);
                await this.DbContext.SaveChangesAsync();
            }
            return region;
        }

        public async Task<Region> Update(Guid id, Region _region)
        {
            var exitingregion = await this.DbContext.Regions.FindAsync(id);
            if (exitingregion != null)
            {
                exitingregion.Area = _region.Area;
                exitingregion.Name = _region.Name;
                exitingregion.Lat = _region.Lat;
                exitingregion.Long = _region.Long;
                exitingregion.Code = _region.Code;
                exitingregion.Population = _region.Population;

                await this.DbContext.SaveChangesAsync();
            }
            return exitingregion;
        }
    }
}

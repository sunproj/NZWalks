using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repo
{
    public interface IRegionRepo
    {
        Task<IEnumerable<Region>> GetAllAsync();
        IEnumerable<Region> GetAll();

        Task<Region> GetById(Guid id);

        Task<Region> AddAsync(Region _region);

        Task<Region> DeleteById(Guid id);

        Task<Region> Update(Guid id, Region _region);
    }
}

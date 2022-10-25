using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repo
{
    public interface IRegionRepo
    {
        Task<IEnumerable<Region>> GetAllAsync();
        IEnumerable<Region> GetAll();
    }
}

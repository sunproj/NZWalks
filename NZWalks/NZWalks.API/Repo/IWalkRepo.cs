using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repo
{
    public interface IWalkRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Walk>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Walk> GetByIdAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="walk"></param>
        /// <returns></returns>
        Task<Walk> AddWalkAsync(Walk walk);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_walk"></param>
        /// <returns></returns>
        Task<Walk> Update(Guid id, Walk _walk);

        Task<Walk> Delete(Guid id);
    }
}

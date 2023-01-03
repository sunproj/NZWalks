using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repo
{
    public interface ITokenhandler
    {
        Task<string> CreatTokenAsync(User user);
    }
}

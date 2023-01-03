using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repo
{
    public interface IUserRepo
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}

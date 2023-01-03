using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repo
{
    public class StaticUserRepo : IUserRepo
    {
        private List<User> _users = new List<User>()
        {
            new User{
                Guid = Guid.NewGuid(),
                FirstName="Read Only",
                LastName="User",
                Email="rajesh@gmail.com",
                Username="readonly@user.com",
                Password="@1234",
                Roles = new List<string> { "reader","Writer" }

            },
            new User{
                        Guid = Guid.NewGuid(),
                        FirstName="Mahesh",
                        LastName="Kumar",
                        Email="mahesh@gmail.com",
                        Username="mahesh@code",
                        Password="mahe@1234",
                        Roles = new List<string> { "reader" }

            }
        };


        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var _User = _users.Find(x => x.Username.ToLower() == username.ToLower() && x.Password.ToLower() == password.ToLower());

            return _User;
        }
    }
}

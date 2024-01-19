using recipesv2.Data;
using recipesv2.Helpers;
using recipesv2.Models;

namespace recipesv2.Interfaces.Repositories
{
    public interface ISessionRepository
    {
        public Task SaveUserToDatabase(User user);

        public Task<User?> SearchUserByUsername(string username);
    }
}

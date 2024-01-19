using recipesv2.Models;

namespace recipesv2.Interfaces.Repositories
{
    public interface IProfileRepository
    {
        public Task<User?> FetchUserByUsername(string username);
    }
}
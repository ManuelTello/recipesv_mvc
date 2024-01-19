using Microsoft.EntityFrameworkCore;
using recipesv2.Data;
using recipesv2.Interfaces.Repositories;
using recipesv2.Models;

namespace recipesv2.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DataContext Context;

        public ProfileRepository(DataContext context)
        {
            this.Context = context;
        }

        public async Task<User?> FetchUserByUsername(string username)
        {
            User? user = await this.Context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return user;
        }
    }
}
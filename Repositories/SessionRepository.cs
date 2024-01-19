using Microsoft.EntityFrameworkCore;
using recipesv2.Data;
using recipesv2.Interfaces.Repositories;
using recipesv2.Models;

namespace recipesv2.Repositories
{
    public class SessionRespository : ISessionRepository
    {
        private readonly DataContext Context;


        public SessionRespository(DataContext context)
        {
            this.Context = context;
        }

        public async Task SaveUserToDatabase(User user)
        {
            await this.Context.Users.AddAsync(user);
            await this.Context.SaveChangesAsync();
        }

        public async Task<User?> SearchUserByUsername(string username)
        {
            User? user = await this.Context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return user;
        }
    }
}
using recipesv2.Data;
using recipesv2.Interfaces.Services;
using recipesv2.Models;
using recipesv2.Repositories;
using recipesv2.ViewModels.Session;

namespace recipesv2.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ProfileRepository Repository;

        public ProfileService(DataContext context)
        {
            this.Repository = new ProfileRepository(context);
        }

        public async Task<PortalViewModel> FetchUserForPortalInformation(string username)
        {
            User? user = await this.Repository.FetchUserByUsername(username);

            PortalViewModel viewmodel = new PortalViewModel()
            {
                User = user
            };

            return viewmodel;
        }
    }
}
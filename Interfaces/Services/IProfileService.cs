using recipesv2.ViewModels.Session;

namespace recipesv2.Interfaces.Services
{
    public interface IProfileService
    {
        public Task<PortalViewModel> FetchUserForPortalInformation(string username);
    }
}
using Microsoft.AspNetCore.Mvc;
using recipesv2.Data;
using recipesv2.Services;
using recipesv2.ViewModels.Session;

namespace recipesv2.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ProfileService Service;

        public ProfileController(DataContext context)
        {
            this.Service = new ProfileService(context);
        }

        [HttpGet]
        [Route("[controller]/{username}/[action]")]
        public async Task<IActionResult> ProfilePortal(string username)
        {
            try
            {
                // Checks if theres a session for the user, if so then you can edit the profile
                // information & if not, you can read the profile information (when is public).
                string? session = this.HttpContext.Session.GetString("AspSession");

                if (session != null && session == username)
                {
                    /***  TBA  ***/
                    // Possiblity of edit the profile 
                    PortalViewModel viewmodel = await this.Service.FetchUserForPortalInformation(username);
                    return View("ProfilePortal", viewmodel);
                }
                else
                {
                    PortalViewModel viewmodel = await this.Service.FetchUserForPortalInformation(username);
                    return View("ProfilePortal", viewmodel);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sorry and error ocurred");
            }
        }
    }
}
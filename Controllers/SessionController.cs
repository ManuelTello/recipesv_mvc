using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using recipesv2.Data;
using recipesv2.Helpers;
using recipesv2.Services;
using recipesv2.ViewModels.Session;

namespace recipesv2.Controllers
{
    public class SessionController : Controller
    {
        private readonly SessionService Service;

        public SessionController(DataContext context)
        {
            this.Service = new SessionService(context);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            SignInViewModel model = new SignInViewModel();
            return View("SignIn", model);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            try
            {
                // Validates the model.
                ValidationCompleted validation = await this.Service.SignInUser(model);

                foreach (var error in validation.Errors)
                {
                    this.ModelState.AddModelError(error.Key, error.Value);
                }

                if (!ModelState.IsValid)
                {
                    // If the modelstate is not valid, resets the password and username. 
                    this.ModelState.SetModelValue("Username", new ValueProviderResult("", CultureInfo.InvariantCulture));
                    this.ModelState.SetModelValue("Password", new ValueProviderResult("", CultureInfo.InvariantCulture));
                    return View("SignIn", model);
                }
                else
                {
                    this.HttpContext.Session.SetString(".AspSession", model.Username);
                    return RedirectToAction("ProfilePortal", "Profile", new { username = model.Username });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sorry an error ocurred.");
            }
        }

        [HttpGet]
        public IActionResult SignUp()
        {

            SignUpViewModel model = new SignUpViewModel();
            return View("SignUp", model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            try
            {
                // Validates the model.
                ValidationCompleted operation = await this.Service.SaveNewUserToDatabase(model);

                foreach (var error in operation.Errors)
                {
                    this.ModelState.AddModelError(error.Key, error.Value);
                }

                if (!this.ModelState.IsValid)
                {
                    // If the model state is not valid, resets the password and confirmation from the model.
                    this.ModelState.SetModelValue("Password", new ValueProviderResult("", CultureInfo.InvariantCulture));
                    this.ModelState.SetModelValue("ConfirmPassword", new ValueProviderResult("", CultureInfo.InvariantCulture));
                    return View("SignUp", model);
                }
                else
                {
                    this.HttpContext.Session.SetString("username", model.Username);
                    return RedirectToAction("ProfilePortal", "Profile", new { username = model.Username });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sorry and error ocurred");
            }
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            this.HttpContext.Session.Remove(".AspSession");
            return RedirectToAction("SignIn");
        }
    }
}

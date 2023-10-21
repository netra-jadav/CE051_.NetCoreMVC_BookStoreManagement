using BookStoreMvc.Models.DTO;
using BookStoreMvc.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreMvc.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService authService;
        public UserAuthenticationController(IUserAuthenticationService authService) 
        { 
            this.authService = authService;
        }
        /*public async Task<IActionResult> Register()
        {
            var model = new RegistrationModel
            {
                Email = "user@gmail.com",
                Username = "netra",
                Name = "Netra",
                Password = "Netra@123",
                PasswordConfirm = "Netra@123",
                Role = "User"
            };
            var result = await authService.RegisterAsync(model);
            return Ok(result.Message);

        }*/
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await authService.LoginAsync(model);
            if(result.StatusCode==1)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData["msg"] = "Couldn't Log In";

                return RedirectToAction(nameof(Login));

            }
        }

        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SnakeWebApplication.DataBase;

namespace SnakeWebApplication.Views.Home
{
    public class LoginModel : PageModel
    {
        private DataBaseController _controller;
        public LoginModel()
        {
            _controller= new DataBaseController();
            Username = "";
            Password = "";
        }

        [BindProperty] public string Username { get; set; }
        [BindProperty] public string Password { get; set; }

        public void OnGet()
        {
            GlobalOptions.IsLoggedIn = false;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            if (!_controller.LogInUser(Username, Password)) return Page();
            GlobalOptions.IsLoggedIn = true;
            GlobalOptions.Username = Username;
            return RedirectToPage("/Menu");
        }
    }
}
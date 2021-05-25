using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZamkDb.ViewModels;

namespace ZamkDb.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }
        //[BindProperty]
        //public string Password { get; set; }
        [BindProperty]
        public bool RememberMe { get; set; }
        public SignInManager<IdentityUser> SignIn { get; }

        [BindProperty]
        public LoginViewModel LoginViewModel { get; set; }
        
        public LoginModel(SignInManager<IdentityUser> signIn)
        {
            SignIn = signIn;
        }

        public string URL { get; set; }

        public void OnGet(string ReturnUrl)
        {
            URL = ReturnUrl;
        }

        public async Task<IActionResult> OnPost(/*string ReturnUrl*/)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var result = await SignIn.PasswordSignInAsync(UserName, LoginViewModel.Password, RememberMe, false);
                if (result.Succeeded)
                {
	                return RedirectToPage("/Account/LoginSuccess");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid data");
                    return Page();
                }
            }
        }
    }
}

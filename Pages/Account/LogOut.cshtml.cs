using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZamkDb.Pages.Account
{
    public class LogOutModel : PageModel
    {
	    public SignInManager<IdentityUser> SignIn { get; }

	    public LogOutModel(SignInManager<IdentityUser> signIn)
	    {
		    SignIn = signIn;
	    }
	    public void OnGet()
	    {
	    }
	    public async Task<IActionResult> OnPost()
	    {
		    await SignIn.SignOutAsync();
		    return RedirectToPage("/index");
	    }
    }
}

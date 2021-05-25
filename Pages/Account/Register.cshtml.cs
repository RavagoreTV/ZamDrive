using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZamkDb.Models;
using ZamkDb.ViewModels;

namespace ZamkDb.Pages.Account
{
    public class RegisterModel : PageModel
    {
	    private readonly UserManager<IdentityUser> manager;

	    [BindProperty]
	    public Registration Registration { get; set; }
	    public SignInManager<IdentityUser> SignIn { get; }

	    public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signIn)
	    {
		    manager = userManager;
		    SignIn = signIn;
	    }
	    public void OnGet()
	    {
	    }

	    public async Task<IActionResult> OnPostAsync()
	    {
		    if (!ModelState.IsValid)
		    {
			    return Page();
		    }
		    var user = new Participant() { Name = Registration.Name, Address = Registration.Address, Email = Registration.Email, UserName = Registration.Email, canBeDriver = Registration.canBeDriver };
		    if (user != null && user.canBeDriver)
		    {
			    user.DriverId = user.Id;
		    }

		    var result = await manager.CreateAsync(user, Registration.Password);
		    if (result.Succeeded)
		    {
			    await SignIn.SignInAsync(user, isPersistent: false);
			    return RedirectToPage("/Account/RegisterSuccess");
		    }
		    else
		    {
			    foreach (var er in result.Errors)
			    {
				    ModelState.AddModelError("", er.Description);
			    }
			    return Page();
		    }
	    }
    }
}

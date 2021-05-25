using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZamkDb.Models;
using ZamkDb.Services.Interface;

namespace ZamkDb.Pages.Account
{
    public class User_BookingsModel : PageModel
    {
	    private IParticipantService context;

	    public User_BookingsModel(IParticipantService context)
	    {
			this.context = context;
		}

        public Participant Participant { get; set; }

        public IActionResult OnGet(string uid)
        {
	        Participant = context.GetParticipant(uid);
	        if (Participant == null)
	        {
		        return NotFound();
	        }

	        return Page();
        }
    }
}

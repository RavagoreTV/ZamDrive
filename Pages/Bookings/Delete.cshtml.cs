using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZamkDb.Models;
using ZamkDb.Services.Interface;

namespace ZamkDb.Pages.Bookings
{
    public class DeleteModel : PageModel
    {
	    private readonly IBookingService repo;

	    public DeleteModel(IBookingService repo)
	    {
			this.repo = repo;
		}

        [BindProperty]
        public Booking Booking { get; set; }
        public IActionResult OnGet(int id)
        {
	        Booking = repo.GetBooking(id);
	        return Page();
        }

        public IActionResult OnPost(int id)
        {
	        repo.DeleteBooking(id);
	        return RedirectToPage("GetAllBookings");
        }
    }
}

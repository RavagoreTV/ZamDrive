using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZamkDb.Models;
using ZamkDb.Services.Interface;


namespace ZamkDb.Pages.Bookings
{
    [Authorize]
	public class GetAllBookingsModel : PageModel
    {
        
		public IEnumerable<Booking> Bookings { get; private set; }

		private IBookingService repo;

		[BindProperty]
		public Course Course { get; set; }

		[BindProperty] public Participant Participant { get; set; } = new Participant();

		public GetAllBookingsModel(IBookingService repo)
		{
			this.repo = repo;
			Course = new Course();
		}

		public void OnGet()
		{
			Bookings = repo.GetAllBookings();
		}
	}
}

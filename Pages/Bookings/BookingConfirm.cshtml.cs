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
    public class BookingConfirmModel : PageModel
    {
        private readonly IBookingService repo;
        private readonly ICourseService repoC;
        public BookingConfirmModel(IBookingService repo, ICourseService repoC)
        {
            this.repo = repo;
            this.repoC = repoC;
        }
        [BindProperty] public Course Course { get; set; } = new Course();

        [BindProperty]
        public Booking Booking { get; set; } = new Booking();
        public IActionResult OnGet(int tid, string ppoint)
        {
            Booking.CourseId = tid;
            Booking.ChosenPickUpPoint = ppoint;
            Course = repoC.GetCourse(tid);
            return Page();
        }

        public IActionResult OnPost()
        {
            repo.AddBooking(Booking);

            return RedirectToPage("GetAllBookings");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZamkDb.Models;
using ZamkDb.Services.Interface;

namespace ZamkDb.Pages.Bookings
{
    public class CreateModel : PageModel
    {
	    private readonly ICourseService repoC;

        [BindProperty] public Course Course { get; set; } = new Course();
        [BindProperty] public Booking Booking { get; set; } = new Booking();

        //[BindProperty] public IEnumerable<SelectListItem> PickUpPointList { get; set; } = new List<SelectListItem>();

        public CreateModel(ICourseService repoC)
        {
	        this.repoC = repoC;
        }

        public IActionResult OnGet(int tid)
        {
           Booking.CourseId = tid;
           Course = repoC.GetCourse(tid);
           return Page();
        }

        public IActionResult OnPost(int tid)
        {
            return RedirectToPage("BookingConfirm", new { tid = tid, ppoint = Booking.ChosenPickUpPoint });
        }


    }
}
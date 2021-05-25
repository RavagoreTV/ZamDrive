using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZamkDb.Models;
using ZamkDb.Services.Interface;

namespace ZamkDb.Pages.Courses
{
    [Authorize]
    public class GetAllCoursesModel : PageModel
    {
	    private readonly ZamDbContext context;
		[BindProperty]
		public Course Course { get; set; }
		public IEnumerable<Course> Courses { get; set; }
        [BindProperty] public Booking Booking { get; set; } = new Booking();

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }


        private ICourseService _repo;
        
		public int UId { get; set; }

        public GetAllCoursesModel(ZamDbContext context, ICourseService repo)
	    {
		    this.context = context;
            _repo = repo;

        }
	    public IActionResult OnGet(int uid)
	    {
            UId = uid;
            Courses = context.Courses;
            //Courses = _repo.GetAllCourses();

            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Courses = _repo.FilterCourse(FilterCriteria);
            }
            return Page();

        }

    }
}

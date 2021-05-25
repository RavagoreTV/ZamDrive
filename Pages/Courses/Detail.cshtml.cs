using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZamkDb.Models;
using ZamkDb.Services.Interface;

namespace ZamkDb.Pages.Courses
{
    public class DetailModel : PageModel
    {
		private readonly ICourseService _repo;

		public DetailModel(ICourseService repo)
		{
			_repo = repo;
		}

		[BindProperty]
		public Course Course { get; set; }

		public IActionResult OnGet(int id)
		{
			Course = _repo.GetCourse(id);

			if (Course == null)
			{
				return RedirectToPage("GetAllCourses");
			}

			return Page();
		}

		public IActionResult OnPost()
		{
			//Booking course method here
			return RedirectToPage("GetAllCourses");
		}
	}
}

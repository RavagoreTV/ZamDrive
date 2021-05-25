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
    public class EditModel : PageModel
    {

        private readonly ICourseService repository;

        public EditModel(ICourseService repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Course Course { get; set; } = new Course();

        public IActionResult OnGet(int id)
        {
            Course = repository.GetCourse(id);
            return Page();
        }

        public IActionResult OnPost(Course course)
        {
            Course = repository.EditCourse(course);
            return RedirectToPage("/Courses/MyCourses");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZamkDb.Models;
using ZamkDb.Services.Interface;

namespace ZamkDb.Services.EFService
{
	public class EFCourseService : ICourseService
	{
		private readonly ZamDbContext _context;

		public EFCourseService(ZamDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Course> GetAllCourses()
		{
			return _context.Courses;
		}

		public Course GetCourse(int id)
		{
			return _context.Courses.Find(id);
		}

		public Course AddCourse(Course c)
		{
			_context.Courses.Add(c);
			_context.SaveChanges();
			return c;
		}

		public Course DeleteCourse(int id)
		{
			Course course = _context.Courses.Find(id);
			if (course != null)
			{
				_context.Courses.Remove(course);
				_context.SaveChanges();
			}

			return course;

		}

        public Course EditCourse(Course c)
        {
            var course = _context.Courses.Attach(c);
            course.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return c;
        }

        public IEnumerable<Course> FilterCourse(string criteria)
        {
            if (string.IsNullOrEmpty(criteria))
            {
                return _context.Courses;
            }

            return _context.Courses.Where(a => a.ZealandLocation.Contains(criteria));
        }
    }
}

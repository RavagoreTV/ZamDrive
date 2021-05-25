using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ZamkDb.Models
{
	public class ZamDbContext : IdentityDbContext
	{
		public ZamDbContext()
		{

		}

		public ZamDbContext(DbContextOptions<ZamDbContext> dbContextOptions) : base(dbContextOptions)
		{

		}
		public virtual DbSet<Booking> Bookings { get; set; }
		public virtual DbSet<Course> Courses { get; set; }
		public virtual DbSet<Participant> Participants { get; set; }
	}
}

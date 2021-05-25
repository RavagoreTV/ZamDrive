using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ZamkDb.Models
{
	public class Participant : IdentityUser
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Address { get; set; }

		public bool canBeDriver { get; set; }

		[ForeignKey("Participant")]
		public string? DriverId { get; set; }

		public virtual Participant Driver { get; set; }

		public virtual ICollection<Booking> Bookings { get; set; }
		public virtual ICollection<Participant> Participants { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZamkDb.Models
{
	public class Course
	{
		[Key]
		public int CourseId { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		//[Required]
		[StringLength(15)]
		public string ZealandLocation { get; set; }
		public string StartLocation { get; set; }
		public string EndLocation { get; set; }

		//[Required]
		[StringLength(50)]
		public string PickUpPoint1 { get; set; }
		[StringLength(50)]
		public string? PickUpPoint2 { get; set; }
		[StringLength(50)]
		public string? PickUpPoint3 { get; set; }

		//[Required]
		public string UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		public virtual Participant User { get; set; }

        public int AvailableSeats { get; set; }



		public virtual ICollection<Booking> Bookings { get; set; }
    }
}

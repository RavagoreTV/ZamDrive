using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZamkDb.Models
{
	public class Booking
	{
		[Key]
		public int BookingId { get; set; }
		public DateTime Date { get; set; }

		public string ParticipantId { get; set; }

		public Participant Participant { get; set; }

		public int CourseId { get; set; }

		public Course Course { get; set; }

        public string ChosenPickUpPoint { get; set; }
	}
}

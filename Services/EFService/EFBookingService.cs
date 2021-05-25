using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZamkDb.Models;
using ZamkDb.Services.Interface;

namespace ZamkDb.Services.EFService
{
	public class EFBookingService : IBookingService
	{
		private readonly ZamDbContext _context;

		public EFBookingService(ZamDbContext context)
		{
			_context = context;
		}

		public Booking AddBooking(Booking booking)
		{
			_context.Bookings.Add(booking);
			_context.SaveChanges();
			return booking;
		}

		public Booking DeleteBooking(int id)
		{
			Booking booking = _context.Bookings.Find(id);
			if (booking != null)
			{
				_context.Bookings.Remove(booking);
				_context.SaveChanges();
			}

			return booking;
		}

		public Booking GetBooking(int id)
		{
			
			return _context.Bookings.Find(id);
		}

		public IEnumerable<Booking> GetAllBookings()
		{
			//Virker med Programmet
            var booking = _context.Bookings.Include(p => p.Participant).Include(c => c.Course).ThenInclude(u => u.User);
            return booking;

            //Virker kun ved unitTest
            //return _context.Bookings;
        }
	}
}

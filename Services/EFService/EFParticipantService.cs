using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZamkDb.Models;
using ZamkDb.Services.Interface;

namespace ZamkDb.Services.EFService
{
	public class EFParticipantService : IParticipantService
	{
		private readonly ZamDbContext _context;

		public EFParticipantService(ZamDbContext context)
		{
			_context = context;
		}

		public Participant GetParticipant(string id)
		{
			var participant = _context.Participants
				.Include(p => p.Bookings).ThenInclude(c => c.Course)
				.AsNoTracking()
				.FirstOrDefault(m => m.Id == id);
			return participant;
			//return _context.Participants.Find(id);
		}

		public IEnumerable<Participant> GetAllParticipants()
		{
			return _context.Participants;
		}

        public Participant EditParticipant(Participant p)
        {
            var participant = _context.Participants.Where(pa => pa.Id == p.Id).FirstOrDefault();
            participant.canBeDriver = p.canBeDriver;
            participant.Address = p.Address;
            //_context.Participants.Add(participant);
            _context.SaveChanges();

            //var Participant = _context.Participants.Attach(p);
            //Participant.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //_context.SaveChanges();
            return participant;
            
        }
    }
}

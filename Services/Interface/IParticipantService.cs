using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZamkDb.Models;

namespace ZamkDb.Services.Interface
{
	public interface IParticipantService
	{
		Participant GetParticipant(string id);
		IEnumerable<Participant> GetAllParticipants();

        Participant EditParticipant(Participant p);
		
	}
}

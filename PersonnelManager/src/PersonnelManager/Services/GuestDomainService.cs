using PersonnelManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonnelManager.Models;

namespace PersonnelManager.Services
{
    public class GuestDomainService : IGuestDomainService
    {
        private AppDbContext database;
        private List<Guest> guests;

        public GuestDomainService()
        {
            database = new AppDbContext();
            guests = database.Guest.ToList();
        }

        public Guest Add(Guest Guest)
        {
            throw new NotImplementedException();
        }

        public Guest Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Guest> Get()
        {
            return guests.ToList();
        }

        public Guest Get(int id)
        {
            return guests.Where(g => g.Id == id).FirstOrDefault();
        }
    }
}

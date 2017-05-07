using PersonnelManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonnelManager.Models;

namespace PersonnelManager.Services
{
    public class AdministratorDomainService : IAdministratorDomainService
    {
        private AppDbContext database;
        private List<Administrator> administrators;

        public AdministratorDomainService()
        {
            database = new AppDbContext();
            administrators = database.Administrator.ToList();
        }

        public Administrator Add(Administrator Administrator)
        {
            throw new NotImplementedException();
        }

        public Administrator Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Administrator Get(int id)
        {
            return administrators.Where(a => a.Id == id).FirstOrDefault();
        }

        public List<Administrator> Get()
        {
            return administrators.ToList();
        }

        public Administrator Update(Administrator Administrator)
        {
            throw new NotImplementedException();
        }
    }
}

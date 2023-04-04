using CMSWebsite.Data;
using CMSWebsite.Models;
using CMSWebsite.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMSWebsite.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly AppDbContext _appDbContext;

        public RegistrationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Registration model)
        {
            try
            {
                _appDbContext.Registrations.Add(model);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public void Delete(int id)
        {
            try
            {
                Registration registration = _appDbContext.Registrations.Find(id);
                _appDbContext.Registrations.Remove(registration);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Edit(Registration model)
        {
            try
            {
                _appDbContext.Entry(model).State = EntityState.Modified;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public IEnumerable<Registration> GetAll()
        {
            try
            {
                return _appDbContext.Registrations.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public Registration GetById(int id)
        {
            try
            {
                return _appDbContext.Registrations.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}

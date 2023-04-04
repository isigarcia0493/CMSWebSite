using CMSWebsite.Data;
using CMSWebsite.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using CMSWebsite.RepositoryInterfaces;
using System.Linq;

namespace CMSWebsite.Repositories
{
    public class EventRegistrationRepository : IEventRegistrationRepository
    {
        private readonly AppDbContext _appDbContext;

        public EventRegistrationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(EventRegistration model)
        {
            try
            {
                _appDbContext.EventRegistrations.Add(model);
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
                EventRegistration eventRegistration = _appDbContext.EventRegistrations.Find(id);
                _appDbContext.EventRegistrations.Remove(eventRegistration);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Edit(EventRegistration model)
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

        public IEnumerable<EventRegistration> GetAll()
        {
            try
            {
                return _appDbContext.EventRegistrations.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public EventRegistration GetById(int id)
        {
            try
            {
                return _appDbContext.EventRegistrations.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}

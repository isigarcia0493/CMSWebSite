using CMSWebsite.Data;
using CMSWebsite.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using CMSWebsite.RepositoryInterfaces;
using CMSWebsite.RepositoriesInterfaces;
using System.Linq;

namespace CMSWebsite.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _appDbContext;

        public EventRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Event model)
        {
            try
            {
                _appDbContext.Events.Add(model);
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
                Event eventModel = _appDbContext.Events.Find(id);
                _appDbContext.Events.Remove(eventModel);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Edit(Event model)
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

        public IEnumerable<Event> GetAll()
        {
            try
            {
                return _appDbContext.Events.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public Event GetById(int id)
        {
            try
            {
                return _appDbContext.Events.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}

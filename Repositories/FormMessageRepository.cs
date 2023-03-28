using CMSWebsite.Data;
using CMSWebsite.Models;
using CMSWebsite.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CMSWebsite.Repositories
{
    public class FormMessageRepository : IFormMessageRepository
    {
        private readonly AppDbContext _appDbContext;

        public FormMessageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(FormMessage model)
        {
            try
            {
                _appDbContext.FormMessages.Add(model);
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
                FormMessage formMessage = _appDbContext.FormMessages.Find(id);
                _appDbContext.FormMessages.Remove(formMessage);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Edit(FormMessage model)
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

        public IEnumerable<FormMessage> GetAll()
        {
            try
            {
                return _appDbContext.FormMessages.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public FormMessage GetById(int id)
        {
            try
            {
                return _appDbContext.FormMessages.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}

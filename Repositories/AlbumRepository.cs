using CMSWebsite.Data;
using CMSWebsite.Models;
using CMSWebsite.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMSWebsite.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly AppDbContext _appDbContext;

        public AlbumRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Album model)
        {
            _appDbContext.Albums.Add(model);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                Album album = _appDbContext.Albums.Find(id);
                _appDbContext.Albums.Remove(album);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Edit(Album model)
        {
            try
            {
                _appDbContext.Entry(model).State = EntityState.Modified;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable<Album> GetAll()
        {
            try
            {
                return _appDbContext.Albums.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public Album GetById(int id)
        {
            try
            {
                return _appDbContext.Albums.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
    }
}

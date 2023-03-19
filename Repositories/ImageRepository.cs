using CMSWebsite.Data;
using CMSWebsite.Models;
using CMSWebsite.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMSWebsite.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext _appDbContext;

        public ImageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Image model)
        {
            _appDbContext.Images.Add(model);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                Image image = _appDbContext.Images.Find(id);
                _appDbContext.Images.Remove(image);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Edit(Image model)
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

        public IEnumerable<Image> GetAll()
        {
            try
            {
                return _appDbContext.Images.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public Image GetById(int id)
        {
            try
            {
                return _appDbContext.Images.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
    }
}

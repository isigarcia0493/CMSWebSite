using CMSWebsite.Data;
using CMSWebsite.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using CMSWebsite.Models;
using System.Linq;

namespace CMSWebsite.Repositories
{
    public class CarouselRepository : ICarouselRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarouselRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Carousel model)
        {
            _appDbContext.Carousel.Add(model);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                Carousel carousel = _appDbContext.Carousel.Find(id);
                _appDbContext.Carousel.Remove(carousel);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Edit(Carousel model)
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

        public IEnumerable<Carousel> GetAll()
        {
            try
            {
                return _appDbContext.Carousel.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public Carousel GetById(int id)
        {
            try
            {
                return _appDbContext.Carousel.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
    }
}

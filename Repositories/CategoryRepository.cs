using CMSWebsite.Data;
using CMSWebsite.Models;
using CMSWebsite.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CMSWebsite.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Category model)
        {
            _appDbContext.Categories.Add(model);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = _appDbContext.Categories.Find(id);
            _appDbContext.Categories.Remove(category);
            _appDbContext.SaveChanges();
        }

        public void Edit(Category model)
        {
            _appDbContext.Entry(model).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _appDbContext.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _appDbContext.Categories.Find(id);
        }
    }
}

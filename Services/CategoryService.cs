using CMSWebsite.Models;
using CMSWebsite.RepositoriesInterfaces;
using CMSWebsite.RepositoryInterfaces;
using CMSWebsite.ServiceInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace CMSWebsite.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAlbumRepository _albumRepository;

        public CategoryService(ICategoryRepository categoryRepository, IAlbumRepository albumRepository)
        {
            _categoryRepository = categoryRepository;
            _albumRepository = albumRepository;
        }

        public void AddCategory(Category model)
        {
            _categoryRepository.Create(model);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        }

        public void EditCategory(Category model)
        {
            _categoryRepository.Edit(model);
        }

        public IEnumerable<Album> GetAlbumsByCategoryId(int id)
        {
            return _albumRepository.GetAll().Where(a => a.CategoryId == id);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            List<Category> categories = (List<Category>)_categoryRepository.GetAll();

            return categories;
        }

        public Category GetCategoryById(int id)
        {
            Category category = _categoryRepository.GetById(id);

            return category;
        }
    }
}

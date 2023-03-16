using CMSWebsite.Models;
using CMSWebsite.RepositoriesInterfaces;
using CMSWebsite.ServiceInterfaces;
using System.Collections.Generic;

namespace CMSWebsite.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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

using CMSWebsite.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.Collections.Generic;

namespace CMSWebsite.ServiceInterfaces
{
    public interface ICategoryService
    {
        /// <summary>
        /// Retrieves all the categories
        /// </summary>
        /// <returns>List of Categories</returns>
        IEnumerable<Category> GetAllCategories();

        /// <summary>
        /// Gets a specific category
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One category</returns>
        Category GetCategoryById(int id);

        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="model"></param>
        void EditCategory(Category model);

        /// <summary>
        /// Adds a new category
        /// </summary>
        /// <param name="model"></param>
        void AddCategory(Category model);

        /// <summary>
        /// Deletes a category
        /// </summary>
        /// <param name="id"></param>
        void DeleteCategory(int id);
        
    }
}

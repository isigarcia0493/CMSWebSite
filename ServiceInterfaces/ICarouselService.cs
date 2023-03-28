using CloudinaryDotNet.Actions;
using CMSWebsite.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMSWebsite.ServiceInterfaces
{
    public interface ICarouselService
    {
        /// <summary>
        /// Retrieves all Images in Carousel
        /// </summary>
        /// <returns>List of Images in carousel</returns>
        IEnumerable<Carousel> GetAllCarousel(); 

        /// <summary>
        /// Gets a specific image from carousel
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One carousel image</returns>
        Carousel GetCarouselById(int id);

        /// <summary>
        /// Update an carousel image
        /// </summary>
        /// <param name="model"></param>
        void EditCarousel(Carousel model);

        /// <summary>
        /// Adds a new carousel
        /// </summary>
        /// <param name="model"></param>
        void AddCarousel(Carousel model);

        /// <summary>
        /// Deletes a carousel
        /// </summary>
        /// <param name="id"></param>
        void DeleteCarousel(int id);
    }
}

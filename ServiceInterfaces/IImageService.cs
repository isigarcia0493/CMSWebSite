using CloudinaryDotNet.Actions;
using CMSWebsite.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMSWebsite.ServiceInterfaces
{
    public interface IImageService
    {
        /// <summary>
        /// Retrieves all Albums
        /// </summary>
        /// <returns>List of albums</returns>
        IEnumerable<Image> GetAllImages();

        /// <summary>
        /// Gets a specific album
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One album</returns>
        Image GetImageById(int id);

        /// <summary>
        /// Update an album
        /// </summary>
        /// <param name="model"></param>
        void EditImage(Image model);

        /// <summary>
        /// Adds a new album
        /// </summary>
        /// <param name="model"></param>
        void AddImage(Image model);

        /// <summary>
        /// Deletes an album
        /// </summary>
        /// <param name="id"></param>
        void DeleteImage(int id);

        /// <summary>
        /// Adds anew Image to the clud
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        Task<ImageUploadResult> AddImageAsync(IFormFile image);

        /// <summary>
        /// Deletes an imagre form the cloud
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns></returns>
        Task<DeletionResult> DeleteImageAsync(string publicId);
    }
}

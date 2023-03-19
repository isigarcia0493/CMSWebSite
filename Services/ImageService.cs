using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CMSWebsite.Helpers;
using CMSWebsite.Models;
using CMSWebsite.Repositories;
using CMSWebsite.RepositoryInterfaces;
using CMSWebsite.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMSWebsite.Services
{
    public class ImageService : IImageService
    {
        private readonly Cloudinary _cloudinary;
        private readonly IImageRepository _imageRepository;

        public ImageService(IOptions<CloudinarySettings> config, IImageRepository imageRepository)
        {
            var account = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );

            _cloudinary = new Cloudinary( account );
            _imageRepository = imageRepository;
        }

        public void AddImage(Image model)
        {
            _imageRepository.Create(model);
        }

        public async Task<ImageUploadResult> AddImageAsync(IFormFile image)
        {
            var uploadResult = new ImageUploadResult();

            if(image.Length > 0)
            {
                using var stream = image.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(image.FileName, stream),
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public void DeleteImage(int id)
        {
            _imageRepository.Delete(id);
        }

        public async Task<DeletionResult> DeleteImageAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }

        public void EditImage(Image model)
        {
            _imageRepository.Edit(model);
        }

        public IEnumerable<Image> GetAllImages()
        {
            List<Image> images = (List<Image>)_imageRepository.GetAll();

            return images;
        }

        public Image GetImageById(int id)
        {
            Image image = _imageRepository.GetById(id);

            return image;
        }
    }
}

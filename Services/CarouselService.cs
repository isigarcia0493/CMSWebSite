using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using CMSWebsite.Helpers;
using CMSWebsite.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using CMSWebsite.Models;
using CMSWebsite.ServiceInterfaces;

namespace CMSWebsite.Services
{
    public class CarouselService : ICarouselService
    {
        private readonly ICarouselRepository _carouselRepository;

        public CarouselService(ICarouselRepository carouselRepository)
        {
            _carouselRepository = carouselRepository;
        }

        public void AddCarousel(Carousel model)
        {
            _carouselRepository.Create(model);
        }        

        public void DeleteCarousel(int id)
        {
            _carouselRepository.Delete(id);
        }

        public void EditCarousel(Carousel model)
        {
            _carouselRepository.Edit(model);
        }

        public IEnumerable<Carousel> GetAllCarousel()
        {
            List<Carousel> carousels = (List<Carousel>)_carouselRepository.GetAll();

            return carousels;
        }

        public Carousel GetCarouselById(int id)
        {
            Carousel carousel = _carouselRepository.GetById(id);

            return carousel;
        }
    }
}

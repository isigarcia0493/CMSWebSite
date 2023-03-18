using CMSWebsite.Models;
using CMSWebsite.RepositoriesInterfaces;
using CMSWebsite.RepositoryInterfaces;
using CMSWebsite.ServiceInterfaces;
using System.Collections.Generic;

namespace CMSWebsite.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public void AddAlbum(Album model)
        {
            _albumRepository.Create(model);
        }

        public void DeleteAlbum(int id)
        {
            _albumRepository.Delete(id);
        }

        public void EditAlbum(Album model)
        {
            _albumRepository.Edit(model);
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            List<Album> albums = (List<Album>)_albumRepository.GetAll();

            return albums;
        }

        public Album GetAlbumById(int id)
        {
            Album album = _albumRepository.GetById(id);

            return album;
        }
    }
}

using CMSWebsite.Models;
using System.Collections.Generic;

namespace CMSWebsite.ServiceInterfaces
{
    public interface IAlbumService
    {
        /// <summary>
        /// Retrieves all Albums
        /// </summary>
        /// <returns>List of albums</returns>
        IEnumerable<Album> GetAllAlbums();

        /// <summary>
        /// Gets a specific album
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One album</returns>
        Album GetAlbumById(int id);

        /// <summary>
        /// Update an album
        /// </summary>
        /// <param name="model"></param>
        void EditAlbum(Album model);

        /// <summary>
        /// Adds a new album
        /// </summary>
        /// <param name="model"></param>
        void AddAlbum(Album model);

        /// <summary>
        /// Deletes an album
        /// </summary>
        /// <param name="id"></param>
        void DeleteAlbum(int id);
    }
}

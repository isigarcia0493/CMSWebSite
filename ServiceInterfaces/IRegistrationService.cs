using CMSWebsite.Models;
using System.Collections.Generic;

namespace CMSWebsite.ServiceInterfaces
{
    public interface IRegistrationService
    {
        /// <summary>
        /// Retrieves all Registrations 
        /// </summary>
        /// <returns>List of REgistrations</returns>
        IEnumerable<Registration> GetAllRegistrations();

        /// <summary>
        /// Gets a specific REgistration
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One registration</returns>
        Registration GetRegistrationById(int id);

        /// <summary>
        /// Update an a regitration
        /// </summary>
        /// <param name="model"></param>
        void EditRegistration(Registration model);

        /// <summary>
        /// Adds a new registration
        /// </summary>
        /// <param name="model"></param>
        void AddRegistration(Registration model);

        /// <summary>
        /// Deletes a registration
        /// </summary>
        /// <param name="id"></param>
        void DeleteRegistration(int id);
    }
}

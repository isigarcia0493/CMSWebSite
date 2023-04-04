using CMSWebsite.Models;
using System.Collections.Generic;

namespace CMSWebsite.ServiceInterfaces
{
    public interface IEventRegistrationService
    {
        /// <summary>
        /// Retrieves all Event registrations
        /// </summary>
        /// <returns>List of events registered</returns>
        IEnumerable<EventRegistration> GetAllEventRegistration();

        /// <summary>
        /// Gets a specific event registered
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One event registered</returns>
        EventRegistration GetEventregisteredById(int id);


        /// <summary>
        /// Adds a new event registered
        /// </summary>
        /// <param name="model"></param>
        void AddEventRegistration(EventRegistration model);

        /// <summary>
        /// Deletes an Event
        /// </summary>
        /// <param name="id"></param>
        void DeleteEventRegistered(int id);
    }
}

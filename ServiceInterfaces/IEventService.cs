using CMSWebsite.Models;
using System.Collections.Generic;

namespace CMSWebsite.ServiceInterfaces
{
    public interface IEventService
    {
        /// <summary>
        /// Retrieves all events
        /// </summary>
        /// <returns>List of events</returns>
        IEnumerable<Event> GetAllEvents();

        /// <summary>
        /// Gets a specific event
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One event</returns>
        Event GetEventById(int id);

        /// <summary>
        /// Update an event
        /// </summary>
        /// <param name="model"></param>
        void EditEvent(Event model);

        /// <summary>
        /// Adds a new event
        /// </summary>
        /// <param name="model"></param>
        void AddEvent(Event model);

        /// <summary>
        /// Deletes an event
        /// </summary>
        /// <param name="id"></param>
        void DeleteEvent(int id);
    }
}

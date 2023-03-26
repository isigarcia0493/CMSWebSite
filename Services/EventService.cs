using CMSWebsite.Models;
using CMSWebsite.RepositoryInterfaces;
using CMSWebsite.ServiceInterfaces;
using System.Collections.Generic;

namespace CMSWebsite.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void AddEvent(Event model)
        {
            _eventRepository.Create(model);
        }

        public void DeleteEvent(int id)
        {
            _eventRepository.Delete(id);
        }

        public void EditEvent(Event model)
        {
            _eventRepository.Edit(model);
        }

        public IEnumerable<Event> GetAllEvents()
        {
            List<Event> events = (List<Event>)_eventRepository.GetAll();

            return events;
        }

        public Event GetEventById(int id)
        {
            Event eventModel = _eventRepository.GetById(id);

            return eventModel;
        }
    }
}

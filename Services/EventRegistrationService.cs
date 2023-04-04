using CMSWebsite.Models;
using CMSWebsite.RepositoryInterfaces;
using CMSWebsite.ServiceInterfaces;
using System.Collections.Generic;

namespace CMSWebsite.Services
{
    public class EventRegistrationService : IEventRegistrationService
    {
        private readonly IEventRegistrationRepository _eventRegistrationRepository;

        public EventRegistrationService(IEventRegistrationRepository eventRegistrationRepository)
        {
            _eventRegistrationRepository = eventRegistrationRepository;
        }

        public void AddEventRegistration(EventRegistration model)
        {
            _eventRegistrationRepository.Create(model);
        }

        public void DeleteEventRegistered(int id)
        {
            _eventRegistrationRepository.Delete(id);
        }

        public IEnumerable<EventRegistration> GetAllEventRegistration()
        {
            List<EventRegistration> eventsRegistration = (List<EventRegistration>)_eventRegistrationRepository.GetAll();

            return eventsRegistration;
        }

        public EventRegistration GetEventregisteredById(int id)
        {
            EventRegistration eventRegistration = _eventRegistrationRepository.GetById(id);

            return eventRegistration;
        }
    }
}

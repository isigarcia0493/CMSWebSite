using CMSWebsite.Models;
using CMSWebsite.RepositoryInterfaces;
using CMSWebsite.ServiceInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace CMSWebsite.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IEventRepository _eventRepository;

        public RegistrationService(IRegistrationRepository registrationRepository, IEventRepository eventRepository)
        {
            _registrationRepository = registrationRepository;
            _eventRepository = eventRepository;
        }

        public void AddRegistration(Registration model)
        {
            _registrationRepository.Create(model);
        }

        public void DeleteRegistration(int id)
        {
            _registrationRepository.Delete(id);
        }

        public void EditRegistration(Registration model)
        {
            _registrationRepository.Edit(model);
        }

        public IEnumerable<Registration> GetAllRegistrations()
        {
            List<Registration> registrations = (List<Registration>)_registrationRepository.GetAll();

            return registrations;
        }

        public Registration GetRegistrationById(int id)
        {
            Registration registration = _registrationRepository.GetById(id);

            return registration;
        }

        public IEnumerable<Event> GetEventsByRegistrationId(int id)
        {
            return _eventRepository.GetAll().Where(e => e.EventId == id);
        }

    }
}

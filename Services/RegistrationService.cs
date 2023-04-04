using CMSWebsite.Models;
using CMSWebsite.RepositoryInterfaces;
using CMSWebsite.ServiceInterfaces;
using System.Collections.Generic;

namespace CMSWebsite.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
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
    }
}

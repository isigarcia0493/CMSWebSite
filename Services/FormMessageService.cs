using CMSWebsite.Models;
using CMSWebsite.RepositoryInterfaces;
using CMSWebsite.ServiceInterfaces;
using System.Collections.Generic;

namespace CMSWebsite.Services
{
    public class FormMessageService : IFormMessageService
    {
        private readonly IFormMessageRepository _formMessageRepository;

        public FormMessageService(IFormMessageRepository formMessageRepository)
        {
            _formMessageRepository = formMessageRepository;
        }

        public void AddMessage(FormMessage model)
        {
            _formMessageRepository.Create(model);
        }

        public void DeleteMessage(int id)
        {
            _formMessageRepository.Delete(id);
        }

        public IEnumerable<FormMessage> GetAllMessages()
        {
            List<FormMessage> messages = (List<FormMessage>)_formMessageRepository.GetAll();

            return messages;
        }

        public FormMessage GetMessageById(int id)
        {
            FormMessage message = _formMessageRepository.GetById(id);

            return message;
        }
    }
}

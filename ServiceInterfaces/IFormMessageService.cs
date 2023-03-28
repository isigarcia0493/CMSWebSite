using CMSWebsite.Models;
using System.Collections.Generic;

namespace CMSWebsite.ServiceInterfaces
{
    public interface IFormMessageService
    {
        /// <summary>
        /// Retrieves all messages
        /// </summary>
        /// <returns>List of messages</returns>
        IEnumerable<FormMessage> GetAllMessages();

        /// <summary>
        /// Gets a specific message
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One message</returns>
        FormMessage GetMessageById(int id);

        /// <summary>
        /// Creates a new message
        /// </summary>
        /// <param name="model"></param>
        void AddMessage(FormMessage model);

        /// <summary>
        /// Deletes a message
        /// </summary>
        /// <param name="id"></param>
        void DeleteMessage(int id);
    }
}

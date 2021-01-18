using Contacts.Base.Interface;
using Contacts.Domain.Entity;
using System.Collections.Generic;

namespace Contacts.Domain.Interface.Service
{
    /// <summary>
    /// Interface that implements the contact service.
    /// </summary>
    public interface IContactService : IBaseService<Contact>
    {
        /// <summary>
        /// Lists the contacts.
        /// </summary>
        /// <returns>Return the list of contacts.</returns>
        IList<Contact> ListContacts();

        /// <summary>
        /// Gets the contact.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Return the contact.</returns>
        Contact GetContact(string id);
    }
}

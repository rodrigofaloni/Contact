using Contacts.Base.Interface;
using Contacts.Domain.Entity;
using System.Collections.Generic;

namespace Contacts.Domain.Interface.Repository
{
    /// <summary>
    /// Interface that implements the contact repository.
    /// </summary>
    public interface IContactRepository : IBaseRepository<Contact>
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

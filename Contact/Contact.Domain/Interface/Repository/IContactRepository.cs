using Contacts.Base.Interface;
using Contacts.Domain.Entity;
using System.Collections.Generic;

namespace Contacts.Domain.Interface.Repository
{
    /// <summary>
    /// Interface that implements the contact repository 2.
    /// </summary>
    public interface IContactRepository : IBaseRepository<Contact>
    {
        IList<Contact> ListContacts();

        Contact GetContact(long id);
    }
}

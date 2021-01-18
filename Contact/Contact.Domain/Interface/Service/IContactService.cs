using Contacts.Base.Interface;
using Contacts.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Domain.Interface.Service
{
    /// <summary>
    /// Interface that implements the contact service.
    /// </summary>
    public interface IContactService : IBaseService<Contact>
    {
        IList<Contact> ListContacts();

        Contact GetContact(string id);
    }
}

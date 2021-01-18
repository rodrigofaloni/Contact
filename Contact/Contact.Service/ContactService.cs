using Contacts.Base.Service;
using Contacts.Domain.Entity;
using Contacts.Domain.Interface.Repository;
using Contacts.Domain.Interface.Service;
using System.Collections.Generic;

namespace Contacts.Service
{
    /// <summary>
    /// Class that implements the contact service.
    /// </summary>
    public class ContactService : BaseService<Contact>, IContactService
    {
        /// <summary>
        /// The contact repository.
        /// </summary>
        private IContactRepository contactRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactService"/> class.
        /// </summary>
        /// <param name="contactRepository">The contact repository.</param>
        public ContactService(IContactRepository contactRepository)
            : base(contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public IList<Contact> ListContacts()
        {
            return this.contactRepository.ListContacts();
        }

        public Contact GetContact(string id)
        {
            return this.contactRepository.GetContact(id);
        }
    }
}

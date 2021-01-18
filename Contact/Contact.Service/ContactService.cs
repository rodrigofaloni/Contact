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

        /// <summary>
        /// Lists the contacts.
        /// </summary>
        /// <returns>
        /// Return the list of contacts.
        /// </returns>
        public IList<Contact> ListContacts()
        {
            return this.contactRepository.ListContacts();
        }

        /// <summary>
        /// Gets the contact.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Return the contact.
        /// </returns>
        public Contact GetContact(string id)
        {
            return this.contactRepository.GetContact(id);
        }

        /// <summary>
        /// Amounts the people same CPF.
        /// </summary>
        /// <param name="cpf">The CPF.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Return the amount.</returns>
        public int AmountPeopleSameCpf(string cpf, string id)
        {
            return this.contactRepository.AmountPeopleSameCpf(cpf, id);
        }

        /// <summary>
        /// Amounts the people same CPF.
        /// </summary>
        /// <param name="cnpj">The cnpj.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Return the amount.</returns>
        public int AmountPeopleSameCnpj(string cnpj, string id)
        {
            return this.contactRepository.AmountPeopleSameCnpj(cnpj, id);
        } 
    }
}

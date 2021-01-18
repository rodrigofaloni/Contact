﻿using Contacts.Base.Repository;
using Contacts.Domain.Entity;
using Contacts.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.Data
{
    /// <summary>
    /// Class implements the contact repository.
    /// </summary>
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ContactRepository(BaseContext context)
         : base(context)
        {
        }

        /// <summary>
        /// Lists the contacts.
        /// </summary>
        /// <returns>
        /// Return the list of contacts.
        /// </returns>
        public IList<Contact> ListContacts()
        {
            return this._context.Set<Contact>()
                .Include(x => x.Person)
                .ThenInclude(x=> x.NaturalPerson)
                .Include(x => x.Person)
                .ThenInclude(x => x.LegalPerson)
                .Include(x => x.Person)
                .ThenInclude(x => x.Address).ToList();
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
            return this._context.Set<Contact>()
                .Include(x => x.Person)
                .ThenInclude(x => x.NaturalPerson)
                .Include(x => x.Person)
                .ThenInclude(x => x.LegalPerson)
                .Include(x => x.Person)
                .ThenInclude(x => x.Address).First(x => x.Id == id);
        }
    }
}

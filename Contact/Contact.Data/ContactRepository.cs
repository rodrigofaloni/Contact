using Contacts.Base.Repository;
using Contacts.Domain.Entity;
using Contacts.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.Data
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(BaseContext context)
         : base(context)
        {
        }

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

        public Contact GetContact(long id)
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

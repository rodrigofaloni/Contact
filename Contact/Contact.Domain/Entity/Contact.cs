using Contacts.Base.Entity;
using Contacts.Domain.Enumerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Domain.Entity
{
    /// <summary>
    /// Class that implements the contact.
    /// </summary>
    public class Contact : BaseEntity
    {
        public Person Person { get; set; }
    }
}

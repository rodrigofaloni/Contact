using Contacts.Base.Entity;
using Contacts.Domain.Enumerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Domain.Entity
{
    public class Person : BaseEntity
    {
        public EnumTypePerson Type { get; set; }

        public LegalPerson LegalPerson { get; set; }

        public NaturalPerson NaturalPerson { get; set; }

        public Address Address { get; set; }
    }
}

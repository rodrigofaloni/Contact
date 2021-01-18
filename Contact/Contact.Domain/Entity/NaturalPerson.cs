using Contacts.Base.Entity;
using Contacts.Domain.Enumerator;
using System;

namespace Contacts.Domain.Entity
{
    /// <summary>
    /// Class that implements the natural person.
    /// </summary>
    public class NaturalPerson : BaseEntity
    {
        public string Name { get; set; }

        public string Cpf { get; set; }

        public DateTime Birthday { get; set; }

        public EnumGender Gender { get; set; }
    }
}

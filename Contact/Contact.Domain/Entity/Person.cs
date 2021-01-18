using Contacts.Base.Entity;
using Contacts.Domain.Enumerator;

namespace Contacts.Domain.Entity
{
    /// <summary>
    /// Class that implements the legal person.
    /// </summary>
    public class Person : BaseEntity
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public EnumTypePerson Type { get; set; }

        /// <summary>
        /// Gets or sets the legal person.
        /// </summary>
        public LegalPerson LegalPerson { get; set; }

        /// <summary>
        /// Gets or sets the natural person.
        /// </summary>
        public NaturalPerson NaturalPerson { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public Address Address { get; set; }
    }
}

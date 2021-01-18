using Contacts.Base.Entity;

namespace Contacts.Domain.Entity
{
    /// <summary>
    /// Class that implements the contact.
    /// </summary>
    public class Contact : BaseEntity
    {
        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        public Person Person { get; set; }
    }
}

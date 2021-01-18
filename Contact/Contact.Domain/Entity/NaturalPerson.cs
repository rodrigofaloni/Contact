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
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the CPF.
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        public EnumGender Gender { get; set; }
    }
}

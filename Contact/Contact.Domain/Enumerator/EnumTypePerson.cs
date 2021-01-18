using System.ComponentModel;

namespace Contacts.Domain.Enumerator
{
    /// <summary>
    /// Enumerator that defines the type person.
    /// </summary>
    public enum EnumTypePerson
    {
        /// <summary>
        /// Define type natural.
        /// </summary>
        [Description("NATURAL")]
        NATURAL,

        /// <summary>
        /// Define type legal.
        /// </summary>
        [Description("LEGAL")]
        LEGAL
    }
}

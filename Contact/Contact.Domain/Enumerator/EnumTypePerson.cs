using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Contacts.Domain.Enumerator
{
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

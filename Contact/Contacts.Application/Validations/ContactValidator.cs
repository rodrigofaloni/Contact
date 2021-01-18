﻿using Contacts.Application.Models;
using Contacts.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Application.Validations
{
    /// <summary>
    /// 
    /// </summary>
    public class ContactValidator
    {
        /// <summary>
        /// The contact service
        /// </summary>
        IContactService _contactService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactValidator"/> class.
        /// </summary>
        /// <param name="contactService">The contact service.</param>
        public ContactValidator(IContactService contactService)
        {
            _contactService = contactService;
        }
      
        public void UpdateValidator(ContactVWM contact)
        {
            GeneralValidation(contact);
        }
      
        public void InsertValidator(ContactVWM contact)
        {
            GeneralValidation(contact);
        }

        private void GeneralValidation(ContactVWM contact)
        {
            if (contact == null)
            {
                throw new Exception("Incorret object.");
            }

            if(contact.Type == Domain.Enumerator.EnumTypePerson.NATURAL)
            {
                if (string.IsNullOrEmpty(contact.Name))
                {
                    throw new Exception("The field name is required.");
                }

                if (!contact.Gender.HasValue)
                {
                    throw new Exception("The field gender is required.");
                }

                if (string.IsNullOrEmpty(contact.Cpf))
                {
                    throw new Exception("The field Cpf is required.");
                }

                if (!contact.Birthday.HasValue)
                {
                    throw new Exception("The field birthday is required.");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(contact.CompanyName))
                {
                    throw new Exception("The field company name is required.");
                }

                if (string.IsNullOrEmpty(contact.TradeName))
                {
                    throw new Exception("The field trade name is required.");
                }

                if (string.IsNullOrEmpty(contact.Cnpj))
                {
                    throw new Exception("The field cnpj is required.");
                }
            }

            if (string.IsNullOrEmpty(contact.ZipCode))
            {
                throw new Exception("The field Zip Code is required.");
            }

            if (string.IsNullOrEmpty(contact.Country))
            {
                throw new Exception("The field country is required.");
            }

            if (string.IsNullOrEmpty(contact.State))
            {
                throw new Exception("The field state is required.");
            }

            if (string.IsNullOrEmpty(contact.City))
            {
                throw new Exception("The field city is required.");
            }

            if (string.IsNullOrEmpty(contact.AddressLine1) && string.IsNullOrEmpty(contact.AddressLine2))
            {
                throw new Exception("You must provide at least one address.");
            }
        }
    }
}
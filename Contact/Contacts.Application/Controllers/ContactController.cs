using Contacts.Application.Models;
using Contacts.Application.Validations;
using Contacts.Domain.Entity;
using Contacts.Domain.Enumerator;
using Contacts.Domain.Helper;
using Contacts.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Contacts.Application.Controllers
{
    /// <summary>
    /// Controller responsible for crud contacts.
    /// </summary>
    public class ContactController : Controller
    {
        #region Properties
        /// <summary>
        /// The contact service.
        /// </summary>
        protected readonly IContactService _contactService;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactController"/> class.
        /// </summary>
        /// <param name="contactService">The contact service.</param>
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get the index page of contacts.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Return the index page.</returns>
        public IActionResult Index(string message)
        {
            try
            {
                if (message != null)
                {
                    ViewBag.SucessMessage = message;
                }

                IEnumerable<ContactVWM> listContactVwm = GetContacsVwm();
                return View(listContactVwm);
            }
            catch (Exception erro)
            {
                return Json(new ValidateMessage { Message = erro.Message, IsError = true });
            }
        }

        /// <summary>
        /// Get the AddorEdit page of contacts.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The page.</returns>
        [HttpGet]
        public IActionResult AddOrEdit(string id)
        {
            try
            {
                PrepareViewBags();

                if (string.IsNullOrEmpty(id))
                {
                    return View(new ContactVWM());
                }
                else
                {
                    var dataBaseEntity = _contactService.GetContact(id);
                    ContactVWM contactVwm = ModelToVwm(dataBaseEntity);

                    return View(contactVwm);
                }
            }
            catch (Exception erro)
            {
                return Json(new ValidateMessage { Message = erro.Message, IsError = true });
            }
        }

        /// <summary>
        /// Adds the or edit contacts.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>Return the result of operation.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(ContactVWM contact)
        {
            try
            {
                if (string.IsNullOrEmpty(contact.Id))
                {
                    ContactValidator validator = new ContactValidator(_contactService);
                    validator.InsertValidator(contact);
                    Contact newContact = PrepareNewContact(contact);
                    _contactService.Insert(newContact);
                }
                else
                {
                    ContactValidator validator = new ContactValidator(_contactService);
                    validator.UpdateValidator(contact);
                    var dataBaseEntity = _contactService.GetContact(contact.Id);
                    PrepareUpdateContact(contact, dataBaseEntity);
                    _contactService.Update(dataBaseEntity);
                }

                return Json(true);
            }
            catch (Exception erro)
            {
                return Json(new ValidateMessage { Message = erro.Message, IsError = true });
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Return the result of operation.</returns>
        [HttpPost]
        public IActionResult Delete(string id)
        {
            try
            {
                var employee = _contactService.GetById(id);
                _contactService.Remove(employee);
                return Json(true);
            }
            catch (Exception erro)
            {
                return Json(new ValidateMessage { Message = erro.Message, IsError = true });
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Responsible to convert Models to VWM.
        /// </summary>
        /// <param name="dataBaseEntity">The data base entity.</param>
        /// <returns>Return the entity vwm.</returns>
        private static ContactVWM ModelToVwm(Contact dataBaseEntity)
        {
            var contactVwm = new ContactVWM { Id = dataBaseEntity.Id };
            contactVwm.Type = dataBaseEntity.Person.Type;

            if (dataBaseEntity.Person.Type == EnumTypePerson.NATURAL)
            {
                contactVwm.Name = dataBaseEntity.Person.NaturalPerson.Name;
                contactVwm.Birthday = dataBaseEntity.Person.NaturalPerson.Birthday;
                contactVwm.Gender = dataBaseEntity.Person.NaturalPerson.Gender;
                contactVwm.Cpf = dataBaseEntity.Person.NaturalPerson.Cpf;
            }
            else
            {
                contactVwm.CompanyName = dataBaseEntity.Person.LegalPerson.CompanyName;
                contactVwm.TradeName = dataBaseEntity.Person.LegalPerson.TradeName;
                contactVwm.Cnpj = dataBaseEntity.Person.LegalPerson.Cnpj;
            }

            contactVwm.ZipCode = dataBaseEntity.Person.Address.ZipCode;
            contactVwm.Country = dataBaseEntity.Person.Address.Country;
            contactVwm.State = dataBaseEntity.Person.Address.State;
            contactVwm.City = dataBaseEntity.Person.Address.City;
            contactVwm.AddressLine1 = dataBaseEntity.Person.Address.AddressLine1;
            contactVwm.AddressLine2 = dataBaseEntity.Person.Address.AddressLine2;
            return contactVwm;
        }

        /// <summary>
        /// Gets the contacs VWM.
        /// </summary>
        /// <returns>Return the contacts.</returns>
        private IEnumerable<ContactVWM> GetContacsVwm()
        {
            var listContacts = _contactService.ListContacts();

            var listContactVwm = listContacts.Select(u => new ContactVWM
            {
                Id = u.Id,
                Type = u.Person.Type,
                NameExibition = u.Person.Type == EnumTypePerson.NATURAL ? u.Person.NaturalPerson.Name : u.Person.LegalPerson.CompanyName,
                DocumentExibition = u.Person.Type == EnumTypePerson.NATURAL ? u.Person.NaturalPerson.Cpf : u.Person.LegalPerson.Cnpj,
                ZipCode = u.Person.Address.ZipCode,
            });
            return listContactVwm;
        }

        /// <summary>
        /// Prepares the update contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <param name="dataBaseEntity">The data base entity.</param>
        private void PrepareUpdateContact(ContactVWM contact, Contact dataBaseEntity)
        {
            dataBaseEntity.Person.Type = contact.Type;
            dataBaseEntity.Person.Address.ZipCode = contact.ZipCode;
            dataBaseEntity.Person.Address.City = contact.City;
            dataBaseEntity.Person.Address.State = contact.State;
            dataBaseEntity.Person.Address.Country = contact.Country;
            dataBaseEntity.Person.Address.AddressLine1 = contact.AddressLine1;
            dataBaseEntity.Person.Address.AddressLine2 = contact.AddressLine2;

            if (contact.Type == EnumTypePerson.NATURAL)
            {
                if (dataBaseEntity.Person.NaturalPerson == null)
                {
                    dataBaseEntity.Person.NaturalPerson = new NaturalPerson
                    {
                        Id = _contactService.GetNextId(),
                    };
                    dataBaseEntity.Person.LegalPerson = null;
                }

                dataBaseEntity.Person.NaturalPerson.Birthday = contact.Birthday.Value;
                dataBaseEntity.Person.NaturalPerson.Cpf = contact.Cpf;
                dataBaseEntity.Person.NaturalPerson.Gender = contact.Gender.Value;
                dataBaseEntity.Person.NaturalPerson.Name = contact.Name;
            }
            else
            {
                if (dataBaseEntity.Person.LegalPerson == null)
                {
                    dataBaseEntity.Person.LegalPerson = new LegalPerson
                    {
                        Id = _contactService.GetNextId(),
                    };
                    dataBaseEntity.Person.NaturalPerson = null;
                }

                dataBaseEntity.Person.LegalPerson.Cnpj = contact.Cnpj;
                dataBaseEntity.Person.LegalPerson.CompanyName = contact.CompanyName;
                dataBaseEntity.Person.LegalPerson.TradeName = contact.TradeName;
            }
        }

        /// <summary>
        /// Prepares the new contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>Return the new contact.</returns>
        private Contact PrepareNewContact(ContactVWM contact)
        {
            Contact newContact = new Contact { Id = _contactService.GetNextId() };
            var person = new Person
            {
                Id = _contactService.GetNextId(),
                Type = contact.Type,
                Address = new Address
                {
                    Id = _contactService.GetNextId(),
                    ZipCode = contact.ZipCode,
                    City = contact.City,
                    State = contact.State,
                    AddressLine1 = contact.AddressLine1,
                    AddressLine2 = contact.AddressLine2,
                    Country = contact.Country,
                }
            };

            newContact.Person = person;

            if (contact.Type == EnumTypePerson.NATURAL)
            {
                newContact.Person.NaturalPerson = new NaturalPerson
                {
                    Id = _contactService.GetNextId(),
                    Birthday = contact.Birthday.Value,
                    Cpf = contact.Cpf,
                    Gender = contact.Gender.Value,
                    Name = contact.Name
                };
            }
            else
            {
                newContact.Person.LegalPerson = new LegalPerson
                {
                    Id = _contactService.GetNextId(),
                    Cnpj = contact.Cnpj,
                    CompanyName = contact.CompanyName,
                    TradeName = contact.TradeName
                };
            }

            return newContact;
        }

        /// <summary>
        /// Prepares the view bags.
        /// </summary>
        private void PrepareViewBags()
        {
            var types = new List<EnumTypePerson>();
            types.Add(EnumTypePerson.NATURAL);
            types.Add(EnumTypePerson.LEGAL);
            ViewBag.Types = types;

            var genders = new List<EnumGender>();
            genders.Add(EnumGender.MALE);
            genders.Add(EnumGender.FEMALE);
            ViewBag.Genders = genders;

            ViewBag.Countries = CountryHelper.GetAllCountries();
        }

        #endregion
    }
}
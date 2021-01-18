using Contacts.Application.Models;
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
    public class ContactController : Controller
    {
        protected readonly IContactService _servico;

        public ContactController(IContactService servico)
        {
            _servico = servico;
        }

        // GET: Employee
        public IActionResult Index(string message)
        {
            if(message != null) {
                ViewBag.SucessMessage = message;
            }

            var listItens = _servico.ListContacts();

            var listVwm = listItens.Select(u => new ContactVWM
            {
                Id = u.Id,
                Type = u.Person.Type,
                NameExibition = u.Person.Type == EnumTypePerson.NATURAL ? u.Person.NaturalPerson.Name : u.Person.LegalPerson.CompanyName,
                DocumentExibition = u.Person.Type == EnumTypePerson.NATURAL ? u.Person.NaturalPerson.Cpf : u.Person.LegalPerson.Cnpj,
                ZipCode = u.Person.Address.ZipCode,
                Country = u.Person.Address.Country,
            });

            return View(listVwm);
        }


        // GET: Employee/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            var types = new List<EnumTypePerson>();
            types.Add(EnumTypePerson.NATURAL);
            types.Add(EnumTypePerson.LEGAL);
            ViewBag.Types = types;

            var genders = new List<EnumGender>();
            genders.Add(EnumGender.MALE);
            genders.Add(EnumGender.FEMALE);
            ViewBag.Genders = genders;

            ViewBag.Countries = HelperCountry.GetAllCountries();

            if (id == 0)
            {
                return View(new ContactVWM());
            }
            else
            {
                var dataBaseEntity = _servico.GetContact(id);

                var vwm = new ContactVWM { Id = dataBaseEntity.Id };
                vwm.Type = dataBaseEntity.Person.Type;

                if (dataBaseEntity.Person.Type == EnumTypePerson.NATURAL)
                {
                    vwm.Name = dataBaseEntity.Person.NaturalPerson.Name;
                    vwm.Birthday = dataBaseEntity.Person.NaturalPerson.Birthday;
                    vwm.Gender = dataBaseEntity.Person.NaturalPerson.Gender;
                    vwm.Cpf = dataBaseEntity.Person.NaturalPerson.Cpf;
                }
                else
                {
                    vwm.CompanyName = dataBaseEntity.Person.LegalPerson.CompanyName;
                    vwm.TradeName = dataBaseEntity.Person.LegalPerson.TradeName;
                    vwm.Cnpj = dataBaseEntity.Person.LegalPerson.Cnpj;
                }

                vwm.ZipCode = dataBaseEntity.Person.Address.ZipCode;
                vwm.Country = dataBaseEntity.Person.Address.Country;
                vwm.State = dataBaseEntity.Person.Address.State;
                vwm.City = dataBaseEntity.Person.Address.City;
                vwm.AddressLine1 = dataBaseEntity.Person.Address.AddressLine1;
                vwm.AddressLine2 = dataBaseEntity.Person.Address.AddressLine2;

                return View(vwm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(ContactVWM contact)
        {
            try
            {
                var nextId = _servico.GetNextId();

                if (contact.Id == 0)
                {
                    Contact newContact = new Contact { Id = nextId };
                    var person = new Person
                    {
                        Id = nextId,
                        Type = contact.Type,
                        Address = new Address
                        {
                            Id = nextId,
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
                            Id = nextId,
                            Birthday = contact.Birthday.Value,
                            Cpf = contact.Cpf.Replace(".", string.Empty).Replace("-", string.Empty),
                            Gender = contact.Gender.Value,
                            Name = contact.Name
                        };
                    }
                    else
                    {
                        newContact.Person.LegalPerson = new LegalPerson
                        {
                            Id = nextId,
                            Cnpj = contact.Cnpj.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty),
                            CompanyName = contact.CompanyName,
                            TradeName = contact.TradeName
                        };
                    }

                    _servico.Insert(newContact);
                }
                else
                {
                    var dataBaseEntity = _servico.GetContact(contact.Id);
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
                                Id = nextId,
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
                                Id = nextId,
                            };
                            dataBaseEntity.Person.NaturalPerson = null;
                        }

                        dataBaseEntity.Person.LegalPerson.Cnpj = contact.Cnpj;
                        dataBaseEntity.Person.LegalPerson.CompanyName = contact.CompanyName;
                        dataBaseEntity.Person.LegalPerson.TradeName = contact.TradeName;
                    }

                    _servico.Update(dataBaseEntity);
                }

                return Json(true);
            }
            catch (Exception erro)
            {
                return Json(new ValidateMessage { Message = erro.Message, IsError = true });
            }
        }


        // GET: Employee/Delete/5
        public IActionResult Delete(int id)
        {
            var employee = _servico.GetById(id);
            _servico.Remove(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
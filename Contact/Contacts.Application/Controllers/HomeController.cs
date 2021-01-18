using Contacts.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Application.Controllers
{
    /// <summary>
    /// Controller responsible for home page.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Return the default page.</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}

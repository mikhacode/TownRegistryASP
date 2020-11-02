using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TownRegistryASP.Models;
using TownRegistryASP.ViewModels;

namespace TownRegistryASP.Controllers
{
    public class CitizensController : Controller
    {
        // GET: Citizen
        public ActionResult ViewCitizen()
        {
            var citizen = new Citizen()
            {
                FirstName = "Joe"
            };
            var placeOfBirth = new PlaceOfBirth { City = "New York" };
            var placeOfDeath = new PlaceOfDeath { City = "Denver" };

            var viewModel = new EditCitizenViewModel()
            {
                Citizen = citizen,
                PlaceOfBirth = placeOfBirth,
                PlaceOfDeath = placeOfDeath
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        [Route("Citizens/DateOfBirth/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByMonthOfYear(int year, int month)
        {
            return Content(year + " / " + month);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}
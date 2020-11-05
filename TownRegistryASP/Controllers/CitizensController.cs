using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TownRegistryASP.Models;
using TownRegistryASP.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.MappingViews;

namespace TownRegistryASP.Controllers
{
    public class CitizensController : Controller
    {
        private MyDbContext _context;

        public CitizensController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult NewCitizen()
        {
            var viewModel = new CitizenFormViewModel()
            {
                GenderList = GenderListItems(),
                StateList = StateListItems(),
                StatusList = StatusListItems(),
                Citizen = new Citizen(),
                PlaceOfBirth = new Place(),
                PlaceOfDeath = new Place()
            };
            return View("CitizenForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(CitizenFormViewModel viewModel)
        {
            if (viewModel.Citizen.CitizenID == 0)
            {
                if (viewModel.PlaceOfBirth.City != null)
                {
                    _context.Places.Add(viewModel.PlaceOfBirth);
                    _context.SaveChanges();
                    viewModel.Citizen.PlaceOfBirthID = viewModel.PlaceOfBirth.PlaceID;
                }
                if (viewModel.PlaceOfDeath.City != null)
                {
                    _context.Places.Add(viewModel.PlaceOfDeath);
                    _context.SaveChanges();
                    viewModel.Citizen.PlaceOfDeathID = viewModel.PlaceOfDeath.PlaceID;
                }

                var newCitizen = _context.Citizens.Create();
                newCitizen.FirstName = viewModel.Citizen.FirstName;
                newCitizen.MiddleName = viewModel.Citizen.MiddleName;
                newCitizen.LastName = viewModel.Citizen.LastName;
                newCitizen.Gender = viewModel.Citizen.Gender;
                newCitizen.DateOfBirth = viewModel.Citizen.DateOfBirth;
                newCitizen.PlaceOfBirthID = viewModel.PlaceOfBirth.PlaceID;
                newCitizen.DateOfDeath = viewModel.Citizen.DateOfDeath;
                newCitizen.PlaceOfDeathID = viewModel.PlaceOfDeath.PlaceID;
                newCitizen.Status = viewModel.Citizen.Status;
                newCitizen.Occupation = viewModel.Citizen.Occupation;

                _context.Citizens.Add(newCitizen);
                _context.SaveChanges();
                return RedirectToAction("Index", "Citizens");
            } 
            else
            {
                var existingCitizen = _context.Citizens.Single(c => c.CitizenID == viewModel.Citizen.CitizenID);

                if (existingCitizen.PlaceOfBirthID != 0)
                {
                    var existingPlaceOfBirth = _context.Places.Single(p => p.PlaceID == existingCitizen.PlaceOfBirthID);
                    existingPlaceOfBirth.Street1 = viewModel.PlaceOfBirth.Street1;
                    existingPlaceOfBirth.Street2 = viewModel.PlaceOfBirth.Street2;
                    existingPlaceOfBirth.City = viewModel.PlaceOfBirth.City;
                    existingPlaceOfBirth.State = viewModel.PlaceOfBirth.State;
                    existingPlaceOfBirth.Zipcode = viewModel.PlaceOfBirth.Zipcode;

                    _context.SaveChanges();
                }
                if (existingCitizen.PlaceOfDeathID != 0)
                {
                    var existingPlaceOfDeath = _context.Places.Single(p => p.PlaceID == existingCitizen.PlaceOfDeathID);
                    existingPlaceOfDeath.Street1 = viewModel.PlaceOfDeath.Street1;
                    existingPlaceOfDeath.Street2 = viewModel.PlaceOfDeath.Street2;
                    existingPlaceOfDeath.City = viewModel.PlaceOfDeath.City;
                    existingPlaceOfDeath.State = viewModel.PlaceOfDeath.State;
                    existingPlaceOfDeath.Zipcode = viewModel.PlaceOfDeath.Zipcode;

                    _context.SaveChanges();
                }

                existingCitizen.FirstName = viewModel.Citizen.FirstName;
                existingCitizen.MiddleName = viewModel.Citizen.MiddleName;
                existingCitizen.LastName = viewModel.Citizen.LastName;
                existingCitizen.Gender = viewModel.Citizen.Gender;
                existingCitizen.DateOfBirth = viewModel.Citizen.DateOfBirth;
                existingCitizen.PlaceOfBirthID = viewModel.PlaceOfBirth.PlaceID;
                existingCitizen.DateOfDeath = viewModel.Citizen.DateOfDeath;
                existingCitizen.PlaceOfDeathID = viewModel.PlaceOfDeath.PlaceID;
                existingCitizen.Status = viewModel.Citizen.Status;
                existingCitizen.Occupation = viewModel.Citizen.Occupation;

                _context.SaveChanges();

                return RedirectToAction("Index", "Citizens");
            }
        }

        public ActionResult Edit(int id)
        {
            var citizen = _context.Citizens.SingleOrDefault(c => c.CitizenID == id);

            if (citizen == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CitizenFormViewModel
            {
                Citizen = citizen,
                GenderList = GenderListItems(),
                StateList = StateListItems(),
                StatusList = StateListItems(),
                PlaceOfBirth = _context.Places.SingleOrDefault(p => p.PlaceID == citizen.PlaceOfBirthID),
                PlaceOfDeath = _context.Places.SingleOrDefault(p => p.PlaceID == citizen.PlaceOfDeathID)
            };

            return View("CitizenForm", viewModel);
        }

        public static IEnumerable<SelectListItem> StatusListItems()
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem() {Text = "Living", Value = "Living"},
                new SelectListItem() {Text = "Deceased", Value = "Deceased"},
                new SelectListItem() {Text = "Unknown", Value = "Unknown"},
            };
            return items;
        }
        public static IEnumerable<SelectListItem> GenderListItems()
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem() {Text = "Male", Value = "Male"},
                new SelectListItem() {Text = "Female", Value = "Female"},
                new SelectListItem() {Text = "Other", Value = "Other"},
            };
            return items;
        }

        public static IEnumerable<SelectListItem> StateListItems()
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem() {Text = "Alabama", Value = "AL"},
                new SelectListItem() {Text = "Alaska", Value = "AK"},
                new SelectListItem() {Text = "Arizona", Value = "AZ"},
                new SelectListItem() {Text = "Arkansas", Value = "AR"},
                new SelectListItem() {Text = "California", Value = "CA"},
                new SelectListItem() {Text = "Colorado", Value = "CO"},
                new SelectListItem() {Text = "Connecticut", Value = "CT"},
                new SelectListItem() {Text = "District of Columbia", Value = "DC"},
                new SelectListItem() {Text = "Delaware", Value = "DE"},
                new SelectListItem() {Text = "Florida", Value = "FL"},
                new SelectListItem() {Text = "Georgia", Value = "GA"},
                new SelectListItem() {Text = "Hawaii", Value = "HI"},
                new SelectListItem() {Text = "Idaho", Value = "ID"},
                new SelectListItem() {Text = "Illinois", Value = "IL"},
                new SelectListItem() {Text = "Indiana", Value = "IN"},
                new SelectListItem() {Text = "Iowa", Value = "IA"},
                new SelectListItem() {Text = "Kansas", Value = "KS"},
                new SelectListItem() {Text = "Kentucky", Value = "KY"},
                new SelectListItem() {Text = "Louisiana", Value = "LA"},
                new SelectListItem() {Text = "Maine", Value = "ME"},
                new SelectListItem() {Text = "Maryland", Value = "MD"},
                new SelectListItem() {Text = "Massachusetts", Value = "MA"},
                new SelectListItem() {Text = "Michigan", Value = "MI"},
                new SelectListItem() {Text = "Minnesota", Value = "MN"},
                new SelectListItem() {Text = "Mississippi", Value = "MS"},
                new SelectListItem() {Text = "Missouri", Value = "MO"},
                new SelectListItem() {Text = "Montana", Value = "MT"},
                new SelectListItem() {Text = "Nebraska", Value = "NE"},
                new SelectListItem() {Text = "Nevada", Value = "NV"},
                new SelectListItem() {Text = "New Hampshire", Value = "NH"},
                new SelectListItem() {Text = "New Jersey", Value = "NJ"},
                new SelectListItem() {Text = "New Mexico", Value = "NM"},
                new SelectListItem() {Text = "New York", Value = "NY"},
                new SelectListItem() {Text = "North Carolina", Value = "NC"},
                new SelectListItem() {Text = "North Dakota", Value = "ND"},
                new SelectListItem() {Text = "Ohio", Value = "OH"},
                new SelectListItem() {Text = "Oklahoma", Value = "OK"},
                new SelectListItem() {Text = "Oregon", Value = "OR"},
                new SelectListItem() {Text = "Pennsylvania", Value = "PA"},
                new SelectListItem() {Text = "Rhode Island", Value = "RI"},
                new SelectListItem() {Text = "South Carolina", Value = "SC"},
                new SelectListItem() {Text = "South Dakota", Value = "SD"},
                new SelectListItem() {Text = "Tennessee", Value = "TN"},
                new SelectListItem() {Text = "Texas", Value = "TX"},
                new SelectListItem() {Text = "Utah", Value = "UT"},
                new SelectListItem() {Text = "Vermont", Value = "VT"},
                new SelectListItem() {Text = "Virginia", Value = "VA"},
                new SelectListItem() {Text = "Washington", Value = "WA"},
                new SelectListItem() {Text = "West Virginia", Value = "WV"},
                new SelectListItem() {Text = "Wisconsin", Value = "WI"},
                new SelectListItem() {Text = "Wyoming", Value = "WY"}
            };
            return items;
        }

        // GET: Citizen
        public ActionResult ViewCitizen()
        {
            var citizen = new Citizen()
            {
                FirstName = "Joe"
            };
            var placeOfBirth = new Place { City = "New York" };
            var placeOfDeath = new Place { City = "Denver" };

            var viewModel = new EditCitizenViewModel()
            {
                Citizen = citizen,
                PlaceOfBirth = placeOfBirth,
                PlaceOfDeath = placeOfDeath
            };
            return View(viewModel);
        }

        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

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

            var citizens = _context.Citizens.ToList();

            var viewModel = new CitizenIndexViewModel()
            {
                Citizens = citizens
            };

            // return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
            return View(viewModel);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TownRegistryASP.Models;

namespace TownRegistryASP.ViewModels
{
    public class CitizenFormViewModel
    {
        public IEnumerable<SelectListItem> GenderList { get; set; }
        public IEnumerable<SelectListItem> StateList { get; set; }
        public IEnumerable<SelectListItem> StatusList { get; set; }
        public Citizen Citizen { get; set; }
        public Place PlaceOfBirth { get; set; }
        public Place PlaceOfDeath { get; set; }
    }
}
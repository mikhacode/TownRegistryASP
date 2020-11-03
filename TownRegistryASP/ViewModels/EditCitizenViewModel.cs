using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownRegistryASP.Models;

namespace TownRegistryASP.ViewModels
{
    public class EditCitizenViewModel
    {
        public Citizen Citizen { get; set; }
        public Place PlaceOfBirth { get; set; }
        public Place PlaceOfDeath { get; set; }
    }
}
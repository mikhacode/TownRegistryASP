using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TownRegistryASP.Models
{
    public class Citizen
    {
        public int CitizenID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int PlaceOfBirthID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PlaceOfDeathID { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string Status { get; set; }
        public string Occupation { get; set; }
    }
}
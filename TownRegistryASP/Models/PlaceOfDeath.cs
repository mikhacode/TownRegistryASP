using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TownRegistryASP.Models
{
    public class PlaceOfDeath
    {
        public int PlaceOfDeathID { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    }
}
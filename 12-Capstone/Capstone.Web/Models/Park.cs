using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Park
    {   
        public string ParkCode { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int Elevation { get; set; }
        public int Campsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int Visitors { get; set; }
        public string Quote { get; set; }
        public string QuoteSource { get; set; }
        public string  Description { get; set; }
        public int EntryFee { get; set; }
        public int AnimalSpecies { get; set; }
        public decimal TrailMileage { get; set; }
    }
}

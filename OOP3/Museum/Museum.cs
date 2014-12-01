using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MuseumBuild
{
    [Serializable()]
    public class Museum : Entertainment.Leisure
    {
        public Museum() { }
        public int CountOfExhibit { get; set; }
        public override void initialization()
        {
            address.NumberOfHouse = 0;
            address.Street = "Gikalo";
            CountOfCustomer = 10;
            CountOfHall = 10;
            CountOfExhibit = 100;
        }
    }
}

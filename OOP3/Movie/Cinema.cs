using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Movie
{
    [Serializable()]

    public class Cinema: Entertainment.Leisure
    {
        public Cinema() { }
        public int CountOfSeance { get; set; }
        public override void initialization()
        {
            address.NumberOfHouse = 0;
            address.Street = "Gikalo";
            CountOfCustomer = 10;
            CountOfHall = 10;
            CountOfSeance = 10;
        }
    }
}

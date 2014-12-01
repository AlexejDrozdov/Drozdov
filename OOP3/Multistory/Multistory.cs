using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HighRise
{
    [Serializable()]

    public class Multistory : Houses.House
    {
        public Multistory() { }
        public int CountOfFlower { get; set; }
        public int CountOfPorch { get; set; }
        public int CountOfFlat { get; set; }
        public override void initialization()
        {
            address.NumberOfHouse = 0;
            address.Street = "Gikalo";
            CountInhabitant = 5;
            CountOfFlat = 60;
            CountOfFlower = 9;
            CountOfPorch = 2;
        }
    }
}

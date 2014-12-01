using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hospital
{
    [Serializable]

    public class Infirmary : SpecialBuildings.SpecialBuilding
    {
        public Infirmary() { }
        public int CountOfOperatingRoom { get; set; }

        public override void initialization()
        {
            address.NumberOfHouse = 0;
            address.Street = "Gikalo";
            CountOfCustomer = 10;
            Telephone = 103;
            CountOfOperatingRoom = 100;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BuildOfMilitia
{
    [Serializable()]

    public class Militia: SpecialBuildings.SpecialBuilding
    {
        public Militia() { }
        public int VolumeMonkeyHouse { get; set; }

        public override void initialization()
        {
            address.NumberOfHouse = 0;
            address.Street = "Gikalo";
            CountOfCustomer = 10;
            Telephone = 102;
            VolumeMonkeyHouse = 33;
        }

    }
    
}

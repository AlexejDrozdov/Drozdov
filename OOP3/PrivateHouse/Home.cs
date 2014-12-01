using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PrivateHouse
{
    [Serializable()]

    public class Home : Houses.House
    {
        public Home() { }
        public int Area { get; set; }
        public override void initialization()
        {
            address.NumberOfHouse = 0;
            address.Street = "Gikalo";
            CountInhabitant = 5;
            Area = 100;
        }

    }
}

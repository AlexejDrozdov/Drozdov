using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Shop
{
    [Serializable()]

    public class Store: GovernmentBuildings.GovernmentBuilding
    {
        public Store() { }
        public string TypeOfProduct { get; set; }

        public override void initialization()
        {
            address.NumberOfHouse = 0;
            address.Street = "Gikalo";
            CountOfCustomer = 10;
            TypeOfProduct = "Shoes";
        }
    }
}

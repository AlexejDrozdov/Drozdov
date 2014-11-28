using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Serializable()]
    public class Store: GovernmentBuildings.GovernmentBuilding
    {
        public Store() { }
        public string TypeOfProduct { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entertainment
{
    [Serializable]
    public class Leisure : GovernmentBuildings.GovernmentBuilding
    {
        public int CountOfHall { get; set; }
        public Leisure() { }
    }
}

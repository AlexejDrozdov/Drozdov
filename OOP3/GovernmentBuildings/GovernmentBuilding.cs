using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentBuildings
{
    [Serializable()]
    public class GovernmentBuilding : Builds.Build
    {
        public GovernmentBuilding() { }
        public int CountOFCustomer { get; set; }
    }
}

using System;
using Builds;

namespace GovernmentBuildings
{
    
    [Serializable]
    public class GovernmentBuilding : Build
    {     
        public GovernmentBuilding() { }
        public int CountOfCustomer { get; set; }

    }
}

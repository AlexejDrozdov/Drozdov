using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    [Serializable()]
    public class Infirmary : SpecialBuildings.SpecialBuilding
    {
        public Infirmary() { }
        public int CountOfOperatingRoom { get; set; }
    }
}

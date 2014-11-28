using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Militia
{
    [Serializable()]
    public class BuildOfMilitia: SpecialBuildings.SpecialBuilding
    {
        public BuildOfMilitia() { }
        public int VolumeMonkeyHouse { get; set; }

    }
    
}

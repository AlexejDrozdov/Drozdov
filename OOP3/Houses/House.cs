using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Houses
{
    [Serializable()]
    public class House : Builds.Build
    {
        public House() { }
        public int CountInhabitant { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
    [Serializable()]
    public class Factory : Builds.Build
    {
        public Factory() { }
        public int Pollution { get; set; }
        public int Aray { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
    public class Factory : Builds.Build
    {
        public int Pollution { get; set; }
        public int Aray { get; set; }
    }
}

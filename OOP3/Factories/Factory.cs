using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Factories
{
    [Serializable]
    public class Factory : Builds.Build
    {
        public Factory() { }
        public int Pollution { get; set; }
        public int Aray { get; set; }
        public override void initialization()
        {
            address.NumberOfHouse = 0;
            address.Street = "Gikalo";
            Pollution = 100;
            Aray = 100;
        }
    }
}

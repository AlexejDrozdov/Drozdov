using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Builds
{
    [Serializable()]

    public class Addres
    {
        public Addres() { }
        public string Street { get; set; }
        public int NumberOfHouse { get; set; }

    }
}

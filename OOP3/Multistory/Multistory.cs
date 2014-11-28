using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighRise
{
    [Serializable()]
    public class Multistory : Houses.House
    {
        public Multistory() { }
        public int CountOfFlower { get; set; }
        public int CountOfPorch { get; set; }
        public int CountOfFlat { get; set; }

    }
}

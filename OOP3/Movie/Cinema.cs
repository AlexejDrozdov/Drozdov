using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie
{
    [Serializable()]
    public class Cinema: Entertainment.Leisure
    {
        public Cinema() { }
        public int CountOfSeance { get; set; }
    }
}

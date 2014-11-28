using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumBuild
{
    [Serializable()]
    public class Museum : Entertainment.Leisure
    {
        public Museum() { }
        public int CountOfExhibit { get; set; }
    }
}

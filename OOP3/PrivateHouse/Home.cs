using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrivateHouse
{
    [Serializable()]
    public class Home : Houses.House
    {
        public Home() { }
        public int Area { get; set; }


    }
}

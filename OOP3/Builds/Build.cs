using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Builds
{
    [Serializable()]
    public class Build
    {
        public Addres address = new Addres();
        public Build() { }
        public Addres Address
        {
            get { return address; }
            set { address = value; }

        }
    }
}

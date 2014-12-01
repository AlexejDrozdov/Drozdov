using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Builds
{
    [Serializable()]

    public class Build
    {
        public Addres address = new Addres();

        public Addres Address
        {
            get { return address; }
            set { address = value; }
        }

        public virtual void initialization()
        {
            
        }
    }
}

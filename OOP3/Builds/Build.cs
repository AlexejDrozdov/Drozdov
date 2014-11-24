using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Builds
{
    public class Build
    {
        private Addres addres = new Addres();
        public void GetAddres(string NewStreet, int Number)
        {
            addres = new Addres {NumberOfHouse = Number, Street = NewStreet};
        }

        public virtual void ShowInfo(ref TreeView treeview)
        {

        }
    }
}

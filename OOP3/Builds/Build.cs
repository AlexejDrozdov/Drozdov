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
        public void SetAddres(string NewStreet, int Number)
        {
            addres = new Addres {NumberOfHouse = Number, Street = NewStreet};
        }

        public string GetAddresStreet()
        {
            return addres.Street;
        }

        public int GetAddresNumber()
        {
            return addres.NumberOfHouse;
        }

    }
}

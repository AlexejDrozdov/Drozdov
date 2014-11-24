using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrivateHouse
{
    public class Home : Houses.House
    {
        private int Area;

        public void SetArea(int NewArea)
        {
            Area = NewArea;
        }

        public int GetArea()
        {
            return Area;
        }


    }
}

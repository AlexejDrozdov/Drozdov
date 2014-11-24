using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Houses
{
    public class House : Builds.Build
    {
        private int CountOfInhabitant;

        public void SetCountOfInhabitant(int Inhabitant)
        {
            CountOfInhabitant = Inhabitant;
        }

        public int GetCountOfInhabitant()
        {
            return CountOfInhabitant;
        }
        public int CountInhabitant { get; set; }
    }
}

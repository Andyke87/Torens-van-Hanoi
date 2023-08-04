using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorensVanHanoiDomein
{
    public class Schijf
    {
        public int Diameter { get; set; }

        public Schijf(int diameter)
        {
            Diameter = diameter + 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHLibrary.Managers
{
    public class Coordinate
    {
        public object occupant { set; get; }
        public int Horizontal { set; get; }
        public int Vertical { set; get; }

        public Coordinate(int vert,int horiz) 
        {
            Horizontal = horiz;
            Vertical = vert;
        }
    }
}

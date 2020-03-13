using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Managers
{
    public class Layout
    {
        public TemperatureZone Zone { set; get; }
        public List<List<Coordinate>> Coordinates = new List<List<Coordinate>>();

        public Layout(int horizontal, int vertical,TemperatureZone zone) 
        {
            for (int i = 0; i <= horizontal; i++)
            {
                List<Coordinate> column = new List<Coordinate>();
                for (int j = 0; j <= vertical; j++) 
                {
                    Coordinate coordinate = new Coordinate(j,i);
                    column.Add(coordinate);
                }
                Coordinates.Add(column);
            }

            Zone = zone;
        }
    }
}

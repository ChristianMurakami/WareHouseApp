using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class AdminControls//holds specific settings such as times and weights so they can be changed without the ide 
    {
        public static int HeavyPlacementControl { set; get; }//how high can heavies be placed
        public static int HollowPlacementControl { set; get; }//how low can hollows be placed
        public static int HollowControl { set; get; }//what products are hollow, hollow controled individually as well
        public static int HeavyControl { set; get; } //what products are heavy
        public static int DistanceControl {set; get;} // seconds given per slot distance
        public static int TimePerPick { set; get; }//time given for each case....maybe better set in Algorthym
        public static int TimeToDock { set; get; }//time gievn to drop trips at dock or to drop old pallets picked up lift drivers 
        public AdminControls()
        {
            DistanceControl = 2;
            HeavyPlacementControl = 45;
            HollowPlacementControl = 25;
            HollowControl = 3;
            TimePerPick = 5;
        }

    }
}

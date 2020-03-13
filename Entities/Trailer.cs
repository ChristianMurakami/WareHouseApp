using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2
{
    public enum TrailerType
    {
        Receiving,
        Shipping,
        ShippingTempControlled,
        Utility
    }
    public class Trailer
    {
        [Key]
        public int Id { set; get; }

        public int DoorNumber { set; get; }//position 0 == in yard
        public TrailerType TrailerType { set; get; }
        public List<Trip> Trips { set; get; }
        public double TempControlled { set; get; }
        public double tempSet { set; get; }
        public Trailer() { }
        public Trailer(TrailerType type)
        {
            TrailerType = type;
        }
    }
}

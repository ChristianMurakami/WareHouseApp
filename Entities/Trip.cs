using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2
{
    public class Pick //sets products, the amount of them needed, and thier location, along with controls to make the process safe against misprofiles
    {
        public int SlotId { set; get; }
        public int CaseCount { set; get; }
        public int ProductId { set; get; }
        public double CubicFeet { set; get; }
        public bool isHeavy { set; get; }
        public bool isHoLLow { set; get; }

        public Pick(int slot,int count,int prod,double cube)
        {
            SlotId = slot;
            CaseCount = count;
            ProductId = prod;
        }
    }

    public class Trip //is a kind of pallet built of all the products that have been picked based on store orders
    {
        [Key]
        public string TripId { set; get; }

        public User AssignedUser { set; get; }
        public int StoreNumber { set; get; }
        TemperatureZone temperatureZone {set; get; }
        public double CubicFeet { private set; get; }
        public int CaseCount { set; get; }
        public TimeSpan StandardTime { private set; get; }
        public TimeSpan ActualTime { private set; get; }
        public Trip() { }
        public Trip(int storeNum,string orderDate,int count,TemperatureZone temp)//change to picks
        {
            TripId = storeNum.ToString() + ":" + orderDate + ":" + temp.ToString() + ":" + count.ToString();
            temperatureZone = temp; 
            StandardTime = standardTime();
            CubicFeet = Cfeet(Picks);
        }
        public List<Pick> Picks = new List<Pick>();
        public void ActionPick()//trips will be completed in standard time?//complete method in form? in user? in interface?
        {
            
        }
        public double Cfeet(List<Pick> picks)//this seems unnecessary now //need to update cubic feet outside of constructor....//change to onADDfuntion for picks
        {
            double Cubes = 0;
            if (picks != null)
            {
                foreach (Pick p in picks)
                {
                    Cubes += p.CubicFeet;
                }
            }
            else { throw new Exception("picks in this trip are null"); }
            return Cubes;
        }
        public TimeSpan standardTime()
        {
            int from = 0;
            int to = 0;
            double Total = 0;
            double Distancetime = AdminControls.DistanceControl;//make class to hold time objects?
            double PickTime = AdminControls.TimePerPick;
            int distance;
            foreach (Pick p in Picks)
            {             
                if (from == 0)//or is the start of trip
                {
                    from = p.SlotId;
                }
                else 
                {
                    to = p.SlotId;                  
                    distance = to - from;                    
                    Total += (Distancetime * distance) + (PickTime * p.CaseCount);
                }                
            }
            TimeSpan timeSpan = new TimeSpan(0, 0, int.Parse(Total.ToString()));
            return timeSpan;
        }
    }
}

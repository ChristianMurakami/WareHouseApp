using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class TripSort
    {
        public List<Trip> PickSort(List<StoreOrder> Orders)//if there are products that are the same but not consequetive in this list then it will not work properly                                                   //this needs to be standard                                                   //have checks
        {
            List<Trip> trips = new List<Trip>();
            foreach (StoreOrder order in Orders)
            {
                int StoreId = order.StoreNumber;
                List<Pick> MP = new List<Pick>();
                List<Pick> FZ = new List<Pick>();  //intialize pick lists
                List<Pick> Dry = new List<Pick>();
                                              
                Product previous = null;

                foreach (Product p in order.products)//sort by temp areas
                {                   
                    if (p.Zone == TemperatureZone.Dry)//this might not be the best......make sure nothing falls threw here.....like list of ordered items that aren't assigned
                    {
                        if (previous == null || previous != p)
                        {
                            if (p.SlotId != 0)
                            {
                                Pick pick = new Pick(p.SlotId, 1, p.Id, p.CubicFeet);
                                if (p.isHeavy) {pick.isHeavy = true;}
                                if (p.isHollow) {pick.isHoLLow = true; }//assign heavy/hollow status
                                Dry.Add(pick);
                            }
                        }
                        else if (previous == p)
                        {
                            if (p.SlotId != 0) { Dry.Last().CaseCount += 1; }
                        }
                        else { throw new Exception($"this product {p.Name} has no assigened to a slot, please check it's status"); }
                    }
                    else if (p.Zone == TemperatureZone.MP)
                    {
                        if (previous == null || previous != p)
                        {
                            if (p.SlotId != 0)
                            {
                                Pick pick = new Pick(p.SlotId, 1, p.Id, p.CubicFeet);
                                if (p.isHeavy) { pick.isHeavy = true; }
                                if (p.isHollow) { pick.isHoLLow = true; }
                                MP.Add(pick);
                            }
                        }
                        else if (previous == p)
                        {
                            if (p.SlotId != 0) { MP.Last().CaseCount += 1; }
                        }
                        else { throw new Exception($"this product {p.Name} has no assigened to a slot, please check it's status"); }
                    }
                    else if (p.Zone == TemperatureZone.FZ)
                    {
                        if (previous == null || previous != p)
                        {
                            if (p.SlotId != 0)
                            {
                                Pick pick = new Pick(p.SlotId, 1, p.Id, p.CubicFeet);
                                if (p.isHeavy) { pick.isHeavy = true; }
                                if (p.isHollow) { pick.isHoLLow = true; }
                                FZ.Add(pick);
                            }
                        }
                        else if (previous == p)
                        {
                            if (p.SlotId != 0) { FZ.Last().CaseCount += 1; }
                        }
                        else { throw new Exception($"this product {p.Name} has no assigened to a slot, please check it's status"); }
                    }
                    else { throw new Exception("product zone data corrupted"); }
                    previous = p;
                }
                string date = order.Date.Month + "/" + order.Date.Day;

                trips =
                TripsBreakdown(MP,StoreId,70.0,date,TemperatureZone.MP);//Max cubes differ due to trailer equipment
                TripsBreakdown(Dry,StoreId,74.0,date, TemperatureZone.Dry);
                TripsBreakdown(FZ,StoreId,68.0,date, TemperatureZone.FZ);               
            }
            return trips;
        }

        public List<Trip> TripsBreakdown(List<Pick> picks,int StoreNum,double Max,string orderDate,TemperatureZone zone)
        {
            int tripcount = 1;
            Trip first = new Trip(StoreNum, orderDate, tripcount, zone);
            List<Trip> trips = new List<Trip>();
            trips.Add(first);

            double HollowControl = AdminControls.HollowControl; // don't want to put hollow cases on trips early
            double HeavyControl = AdminControls.HeavyControl; // don't want people lifting heavy cases above certain height in a trip
           
            List<Pick> Heavies = new List<Pick>();
            List<Pick> Hollows = new List<Pick>();

            foreach(Pick p in picks)
            {
                if (trips.Last().Picks is null || trips.Last().CubicFeet + p.CubicFeet <= Max)
                {
                    while (Heavies.Count() > 0 && trips.Last().CubicFeet <= HeavyControl)
                    {
                        trips.Last().Picks.Add(Heavies.Last());
                        Heavies.Remove(Heavies.Last());
                    }
                    while (Hollows.Count > 0 && trips.Last().CubicFeet >= HollowControl && trips.Last().CubicFeet <= Max)
                    {
                        trips.Last().Picks.Add(Hollows.Last());
                        Heavies.Remove(Hollows.Last());
                    }
                }
                else
                {
                    tripcount += 1;
                    Trip next = new Trip(StoreNum, orderDate, tripcount, zone);
                    trips.Add(next);
                }                
            }
           return trips;         
        }               
    }
}

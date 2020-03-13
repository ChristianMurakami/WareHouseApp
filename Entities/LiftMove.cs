using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2
{
    public enum MoveType
    {
        PutAway,
        Prevent,
        Replenish,
        Remove,
        Switch
    }
    public class LiftMove
    {
        [Key]
        public int Id { set; get; }
       
        public TimeSpan StandardTime { private set; get; }
        public TimeSpan ActualTime { private set; get; }
        public MoveType Mtype { set; get; }
        public DateTime Selected { set; get; }
        public DateTime Finished { set; get; }
        public int CurrentPos { set; get; }
        public double PercentPerformance { private set; get; }
        public Slot From { set; get; }
        public Slot To { set; get; }
        public bool Forced { set; get; }//this would affect what the driver could see in thier move list, this move would be all they could see
                                        //since there is no view that will be built to reflect this it will not be used at this time
        public User AssignedUser { set; get; }//foreign key 

        public LiftMove() { }
        public LiftMove(Slot from, Slot to, MoveType mType)
        {
            To = to;
            From = from;
            Mtype = mType;
            StandardTime = standardTime(CurrentPos,from, to);
        }

        public TimeSpan standardTime(int place,Slot from, Slot to)//poistion
        {
            int distanceMultiplier = AdminControls.DistanceControl; 
            int seconds = (Math.Abs(to.Id - from.Id) + Math.Abs(from.Id - place)) * distanceMultiplier;
            TimeSpan time = new TimeSpan(0,0,seconds);
            return time;
        }
        public TimeSpan actualTime(DateTime Start, DateTime Finish)
        {
            TimeSpan time = new TimeSpan(0, 0, 0);
            time  = Finished - Start;
            return time;
        }
        public double percentPerformance()
        {
            double percent = ActualTime.CompareTo(StandardTime);
            return percent;
        }
    }
}

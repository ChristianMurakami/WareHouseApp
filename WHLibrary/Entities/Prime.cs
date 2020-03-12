using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHLibrary
{
    public class Prime : Slot//primes are floor level, they hold a list of other slots
    {
        List<Slot> UpperSlots { set; get; }
        public Prime(int[][] position, string id,int height)
        {
            Id = id;
            UpperSlots = SetSlots(height);
        }
        public List<Slot> SetSlots(int height)
        {
            List<Slot> slots = new List<Slot>();

            for (int i = 2; i <= height; i++) 
            {
                Slot slot = new Slot(Id + " : " + "R" + i,SlotType.Reserve,50.0);                
                slots.Add(slot);
            } 
            return slots;  
        }
       
    }
}

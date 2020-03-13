using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Prime : Slot//primes are floor level, they hold a list of other slots
    {
        List<Slot> UpperSlots { set; get; }
        public Prime(string aisleName,int length)
        {
            UpperSlots = SetSlots(length);
        }
        public List<Slot> SetSlots(int height)
        {
            List<Slot> slots = new List<Slot>();

            for (int i = 2; i <= height; i++) //1 would be the actual prime
            {
                Slot slot = new Slot();//this will set reserve slots based on height input
                slots.Add(slot);
            } 
            return slots;  
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WHLibrary
{
    public enum TemperatureZone
    {
        Dry,
        MP,
        FZ
    }
    public enum SlotType
    {
        Reserve, //not picked from, hold reserve product
        Pick30, // Pick 30
        Pick20, // step up from floor
        Utility // set aside unassignable slot 
    }

    public class Slot
    {
        [Key]
        public string Id { set; get; }

        public double CubicHeight { set; get; }
        public bool isEmpty { set; get; }
        public Pallet Pallet { set; get; }
        public SlotType SType {set; get;}
        public Slot() { }
        public Slot(string id,SlotType slotType,double cube)
        {
            Id = id;
            CubicHeight = cube;
            isEmpty = Empty();        
        }
        public bool Empty() 
        {
            if (Pallet == null) { return true; }
            else if (Pallet.CaseCount == 0) { return true; }
            else { return false; }
        }
        public void assign(Pallet p)
        {
            if (isEmpty)
            {              
                    if (p.CubicFeet <= CubicHeight)
                    {
                        Pallet = p;
                        isEmpty = false;
                        p.Assigned = true;
                        p.Product.SlotId = Id;
                    }
                    else { throw new Exception("this pallet is too tall for this particular slot"); }
            }            
        }
        public void unAssign()
        {
            if (!isEmpty)
            {
                Pallet = null;
                isEmpty = true;
            }
        }
    }
}

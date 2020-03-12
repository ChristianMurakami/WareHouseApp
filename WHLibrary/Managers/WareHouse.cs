using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace WHLibrary.Managers
{
    public class WareHouse
    {      
        public WHContext WHctx = new WHContext();
        
        public WareHouse(){}      
        public void AssignPallet(Pallet pallet, Slot to)//necessary only for receiving 
        {
            if (to.isEmpty && to.SType == SlotType.Reserve)
            {
                if (to.CubicHeight > pallet.CubicFeet)
                {
                    to.assign(pallet);
                    pallet.Assigned = true;
                }
            }
            else
            {
                if (to.isEmpty == false) { throw new Exception("that slot is currently occupied"); }
                else if (to.SType != SlotType.Reserve) { throw new Exception("this is not a reserve slot"); }
            }
            WHctx.SaveChanges();
        }

        public void TransferPallet(Pallet pallet, Slot from, Slot to)//Protocol to transfer pallet to different slot
        {
            if (to.isEmpty)
            {
                if (to.CubicHeight > pallet.CubicFeet)
                {
                    to.assign(pallet);
                    from.unAssign();
                }
            }
            else
            {
                throw new Exception("that slot is occupied would you like to tranfer it?");//create dialogue for transfer? 
            }
            WHctx.SaveChanges();
        }
        public void AssignUser(User user, Assignment assignment)//assignment class needs to be set up? 
        {
            if (user == null) { throw new Exception("somehow this user is null...."); }
            else  { user.Assignment = assignment; }

            WHctx.SaveChanges();
        }

        public void AssignTrailer(Trailer trailer, int door)
        {
            if (door == 0) { trailer.DoorNumber = 0; }
            else
            {
                foreach (Trailer t in WHctx.Trailers)
                {
                    if (t.DoorNumber == door) { throw new Exception("that door is occupied"); }
                    else { trailer.DoorNumber = door; }
                }
            }
            WHctx.SaveChanges();
        }
        public void AssignProductToSlot (Slot slot, Product product)
        {
            if (product.SlotId != "0") { }
        }
        
        ///////////////////////views////////////////////
        public IEnumerable<Product> UnassignedQueue()//shows all unassigned products
        {
            return WHctx.Products.Where(c => c.SlotId == "0");
        }
        public IEnumerable<Layout> DisplayAislesByTemperature(TemperatureZone z)//reduces view to temperature zones//change this to map
        {
            return WHctx.Layouts.Where(c => c.Zone == z);
        }
        public IEnumerable<User> DisplayUserByAssignment(Assignment assignment)//assignment views
        {
            return WHctx.Users.Where(c => c.Assignment == assignment);
        }
       
        ///////////////////////////////////////////need admin password for these methods//////////////////////////

        public void AddUser(int id, string userName, string pass, bool admin)
        {
            foreach (User u in WHctx.Users)
            {
                if (u.Name == userName || u.Id == id) { throw new Exception("This username or Id already exist, please try different values");}
            }
            User user = new User(id,userName,pass,admin);
            WHctx.Users.Add(user);
        }
        public void AddAisle(string AisleName, TemperatureZone zone, int length, int height)//Add Aisle to current warehouse object//this isn't working correctly 
        { 
            
            WHctx.SaveChanges();
        }

        public void AddSlot(string Name, Coordinate coordinate)//add empty slot to end of aisle object
        {
            
            WHctx.SaveChanges();
        }

        public void RemoveSlot(Slot slot, Layout layout)
        {
            
            WHctx.Slots.Remove(slot);
            WHctx.SaveChanges();
        }
        public void ChangeCoordinate()
        {

        }
        public void ChangeSlotType(Slot slot, SlotType type)
        {
            slot.SType = type;
        }
        
    }
}


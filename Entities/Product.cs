using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ConsoleApp2
{
    public class Product
    {   
        [Key]
        public int Id { set; get; }

        public string SlotId { set; get; }
        public string Name { set; get; }
        public string Company { set; get; }
        public double Height { set; get; }
        public double Width { set; get; }
        public double Weight { set; get; }
        public double CubicFeet { get { return Width * Height; } }
        public TemperatureZone Zone { set; get; }
        public bool isHollow { set; get; }
        public bool isHeavy { set; get; }      
       
        public Product() { }
        public Product(string name, string company, TemperatureZone zone, double height, double width, double weight)
        {
            Name = name;
            Zone = zone;
            Company = company;         
            Height = height;
            Width = width;
            Weight = weight;
            if ((Weight * AdminControls.HollowControl) <= CubicFeet && !isHeavy) { isHollow = true; }
            if (Weight >= AdminControls.HeavyControl) { isHeavy = true; }//change both of these to stored vairables that can be changed by the admin without having to change code          
        }                        
    }
}

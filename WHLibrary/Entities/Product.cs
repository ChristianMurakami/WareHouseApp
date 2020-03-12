using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace WHLibrary
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
      
        }                        
    }
}

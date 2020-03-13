using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2
{
    public class Pallet
    {
        [Key]
        public int PalletId { set; get; }

        public double CubicFeet { set; get; }
        public int CaseCount { set; get; }
        public Product Product { set; get; }
        public bool Assigned { get; set; }
        public Pallet() { }
        public Pallet(int caseCount, Product product)
        {
            CaseCount = caseCount;
            Product = product;
            CubicFeet = Product.CubicFeet * CaseCount;
            Assigned = false;
        }
    }
}

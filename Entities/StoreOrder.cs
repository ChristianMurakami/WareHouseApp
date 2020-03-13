using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ConsoleApp2
{
    public class StoreOrder//necessary? taken from file turned to trips...
    {
        [Key]
        public int Id { set; get; }

        public DateTime Date {set;get;}
        public int StoreNumber { set; get; }
        public List<Product> products = new List<Product>();
        public StoreOrder() { }
        public StoreOrder(int store) { StoreNumber = store;Date = DateTime.Now; }
    }
}

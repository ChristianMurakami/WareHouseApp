using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using ConsoleApp2.Managers;

namespace ConsoleApp2
{
    public class WHContext : DbContext
    {
        public WHContext() :base("name=WHData"){ }
        public DbSet<User> Users{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Pallet> Pallets { get; set; }
        public DbSet<Slot> Slots { get; set;}
        public DbSet<Trailer> Trailers { set; get; }
        public DbSet<Trip> Trips { set; get; }
        public DbSet<LiftMove> Moves { set; get;}
        public DbSet<Layout> Layouts { set; get; }
    }
}

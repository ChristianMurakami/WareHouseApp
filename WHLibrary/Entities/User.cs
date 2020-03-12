using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace WHLibrary
{
    public enum Assignment
    {
        Pick,
        Lift,
        Load,
        Unload,
        Process,
        Chase,
        Unassigned
    }
    public class User
    {
        [Key]
        public int Id { set; get; }

        public string Name { set; get; }
        public string Password { private set; get; }
        public bool Admin { set; get; }
        public Assignment Assignment { set; get; }
        public int Postition { get; set; }
        public User() { }
        public User(int id, string name, string password,bool admin)//set authorization privately? or let admin priveledge control through gui options?
        {
            Id = id;
            Name = name;
            Admin = admin;
            if(passCheck(password) is true) { Password = password; }
        }
        public bool passCheck(string pass)//must have at least one lower one upper and one number // and be 7 long
        {
            var Number = new Regex(@"[0-9]+");
            var Lower = new Regex(@"[a-z]+");
            var Upper = new Regex(@"[A-Z]+");
            var length = 7;

            if (pass.Length < length) { throw new Exception("Passsword requires at least 7 charecters in total"); }

            else if (!Lower.IsMatch(pass)) {throw new Exception("Passsword requires at least one Lower case charecter"); }

            else if (!Upper.IsMatch(pass)) {throw new Exception("Passsword requires at least one Upper case charecter"); }

            else if (!Number.IsMatch(pass)) {throw new Exception("Passsword requires at least one Number");  }

            else { return true; }                     
        }
        
    }
}

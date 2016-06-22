using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifePerformanceMitch.Model
{
   public class Medewerker
    {
       public Medewerker(int id, string naam,string wachtwoord)
       {
           Id = id;
           Naam = naam;
           Wachtwoord = wachtwoord;

       }
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Wachtwoord { get; set; }
    }
}

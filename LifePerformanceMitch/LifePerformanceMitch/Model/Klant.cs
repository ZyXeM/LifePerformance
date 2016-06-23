using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifePerformanceMitch.Model
{
   public class Klant
    {
       public Klant(int id , string naam , string emailadres)
       {
           Id = id;
           Naam = naam;
           Emailadres = emailadres;
       }
        public Klant( string naam, string emailadres)
        {
           
            Naam = naam;
            Emailadres = emailadres;
        }
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Emailadres { get; set; }
    }
}

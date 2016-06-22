using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifePerformanceMitch.Model
{
   public class Huurcontract
    {
       public Huurcontract(int id,DateTime DV, DateTime DT,List<Huur> huur, Klant klant )
       {
           Datum_Tot = DT;
           Datum_Vanaf = DV;
           Huurlijst = huur;
           Id = id;
           Klant = klant;
       }
        public  int Id { get; set; }
        public DateTime Datum_Vanaf { get; set; }
        public DateTime Datum_Tot { get; set; }
        public List<Huur> Huurlijst { get; set; } 
        public Klant Klant { get; set; }
    }
}

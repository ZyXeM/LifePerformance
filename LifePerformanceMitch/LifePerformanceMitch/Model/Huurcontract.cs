using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifePerformanceMitch.Model
{
   public class Huurcontract
    {
       public Huurcontract(DateTime DV, DateTime DT,List<Huur> huur )
       {
           Datum_Tot = DT;
           Datum_Vanaf = DV;
           Huurlijst = huur;
       }
        public DateTime Datum_Vanaf { get; set; }
        public DateTime Datum_Tot { get; set; }
        public List<Huur> Huurlijst { get; set; } 
    }
}

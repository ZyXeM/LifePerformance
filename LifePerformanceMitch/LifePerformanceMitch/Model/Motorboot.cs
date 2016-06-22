using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifePerformanceMitch.Model
{
  public  class Motorboot : Boot
  {
      public Motorboot(string naam, double huurprijs) :base(naam,huurprijs)
        {

        }
        public  int Tankinhoud { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifePerformanceMitch.Model
{
  public  class Motorboot : Boot
  {
      public Motorboot(string naam, decimal huurprijs,string type, int tankinhoud) :base(naam,huurprijs, type)
      {
          Tankinhoud = tankinhoud;
      }
        public  int Tankinhoud { get; set; }
    }
}

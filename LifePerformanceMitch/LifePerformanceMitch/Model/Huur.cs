using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LifePerformanceMitch.Model
{
  public interface Huur
    {
        string Naam { get; set; }
        decimal Huurprijs { get; set; }
       
        
    }
}

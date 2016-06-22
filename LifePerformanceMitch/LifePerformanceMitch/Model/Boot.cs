using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifePerformanceMitch.Model
{
    public class Boot : Huur
    {
        public Boot(string naam, double huurprijs)
        {
            Naam = naam;
            Huurprijs = huurprijs;
        }
        public string Naam { get; set; }
        public double Huurprijs { get; set; }
    }
}

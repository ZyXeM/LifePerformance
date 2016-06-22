using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifePerformanceMitch.Model
{
   public class Artikel : Huur
    {
       public Artikel(int id, int hoeveelheid, string naam, double huurprijs)
       {
           Id = id;
           Hoeveelheid = hoeveelheid;
           Naam = naam;
           Huurprijs = huurprijs;
       }
       public  int Id { get; set; }
       public int Hoeveelheid { get; set; }
       public string Naam { get; set; }
       public double Huurprijs { get; set; }
    }
}

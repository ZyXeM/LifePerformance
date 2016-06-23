using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifePerformanceMitch.Model
{
   public class Artikel : Huur
    {
       public Artikel(int id, int hoeveelheid, string naam, decimal huurprijs)
       {
           Id = id;
           Hoeveelheid = hoeveelheid;
           Naam = naam;
           Huurprijs = huurprijs;
       }
        public Artikel(int id,  string naam, decimal huurprijs)
        {
            Id = id;
           
            Naam = naam;
            Huurprijs = huurprijs;
        }

        public  int Id { get; set; }
       public int Hoeveelheid { get; set; }
       public string Naam { get; set; }
       public decimal Huurprijs { get; set; }
       public override string ToString()
       {
           return "Naam : " + Naam + "Prijs: " + Huurprijs + " " + Hoeveelheid + "X";
        }
    }
}

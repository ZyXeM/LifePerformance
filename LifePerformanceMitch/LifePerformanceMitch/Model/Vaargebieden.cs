using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifePerformanceMitch.Model
{
   public class Vaargebieden
    {
       public Vaargebieden(double dagprijs,string naam,int id , int booten)
       {
           Dagprijs = dagprijs;
           Naam = naam;
           Id = id;
           Motor = motor;
           Spier = spier;

       }
        public double Dagprijs { get; set; }
       public string Naam { get; set; }
       public int  Id { get; set; }
       public bool Motor { get; set; }
        public bool Spier { get; set; }
    }
}

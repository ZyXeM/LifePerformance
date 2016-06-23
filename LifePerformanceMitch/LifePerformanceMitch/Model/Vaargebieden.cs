using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace LifePerformanceMitch.Model
{
   public class Vaargebieden
    {
       public Vaargebieden(decimal dagprijs,string naam,int id , int booten)
       {
           Dagprijs = dagprijs;
           Naam = naam;
           Id = id;
           if (booten == 2)
           {
               Motor = true;
               Spier = true;
           }
           else if (booten == 1)
           {
               Motor = true;
               Spier = false;
           }
           else
           {
               Motor = false;
               Spier = true;
           }
        
       }
        public Vaargebieden(decimal dagprijs, string naam,  int booten)
        {
            Dagprijs = dagprijs;
            Naam = naam;
         
            if (booten == 2)
            {
                Motor = true;
                Spier = true;
            }
            else if (booten == 1)
            {
                Motor = true;
                Spier = false;
            }
            else
            {
                Motor = false;
                Spier = true;
            }

        }
        public decimal Dagprijs { get; set; }
       public string Naam { get; set; }
       public int  Id { get; set; }
       public bool Motor { get; set; }
        public bool Spier { get; set; }
    }
}

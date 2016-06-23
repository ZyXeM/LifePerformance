using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LifePerformanceMitch.Model;
using TweakersRemake;

namespace LifePerformanceMitch
{
    public static class Administratie
    {
        public static List<Huur> Huurlijst { get; set; }
        public static List<Huurcontract> Contractlijst { get; set; }
        public  static  Medewerker Medewerker { get; set; }
        public static List<Vaargebieden> Vaargebieden { get; set; }
        public  static List<Klant> klanten { get; set; } 
         
        public static bool VoegMeerToe(Vaargebieden vaar)
        {
            if (Database.VoegMeerToe(vaar))
            {
                Update();
                return;
            }

        }

        public static bool VoegKlantToe(Klant klant)
        {
          return  Database.VoegKlantToe(klant);
        }

        public static int KrijgActieRadius(Motorboot boot)
        {
            return boot.Tankinhoud*15;
        }

        public static bool VoegHuurcontractToe(Huurcontract huur)
        {
            return Database.VoegHuurcontractToe(huur);
        }

        public static bool ExporteerHuurcontract(Huurcontract huur)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Textfile|*.txt";
               
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                        (System.IO.FileStream) saveFileDialog1.OpenFile();

                    StreamWriter s = new StreamWriter(fs);
                    s.WriteLine("Huurder : " + huur.Klant.Naam);
                    s.WriteLine("Huurcontract vanaf : " + huur.Datum_Vanaf);
                    s.WriteLine("Huurcontract tot : " + huur.Datum_Tot);
                    s.WriteLine("Artikelen :");
                    foreach (var h in huur.Huurlijst)
                    {
                        s.WriteLine("Verhuurde Item : " + h.Naam + " Prijs per dag : " + h.Huurprijs);
                    }


                    fs.Close();
                   
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }
           
            
        }

        public static List<int> BerekenGevoel(HuurcontractForm huur)
        {
            return new List<int>();
        }

        public static void Update()
        {
            klanten = Database.KrijgKlanten();
            Contractlijst = Database.KrijgHuurcontracts();
            Vaargebieden = Database.KrijgVaargebiedens();
            Huurlijst = Database.KrijgHuurLijst();

        }

        public static int KrijgBevarenMeer(Huurcontract huur, decimal budget, List<Vaargebieden> vaar)
        {
            //Ik vraag eerst de dagen tussen de van en tot op en ga daar vervolgens mee rekenen
            int dagen = 0;
            int meren = 0;
            decimal Budget = budget;
            int overboot = 0;
          TimeSpan Lengte =  huur.Datum_Vanaf.Subtract(huur.Datum_Tot);
            dagen = Lengte.Days;
            foreach (var VARIABLE in vaar)
            {
                Budget = Budget - VARIABLE.Dagprijs*dagen;
            }
            foreach (var VARIABLE in huur.Huurlijst)
            {
                Budget = Budget - VARIABLE.Huurprijs * dagen;
            }
            while (budget >= 0)
            {
                foreach (var VARIABLE in huur.Huurlijst)
                {
                    if (VARIABLE is Boot)
                    {
                        
                        if (budget - 1*dagen >= 0 && meren < 6 || ((Boot)VARIABLE).Naam == "Kano")
                        {
                            budget = budget - 1*dagen;
                        }
                        else
                        if (budget - (decimal) (1.50)*dagen >= 0 && meren > 5 && ((Boot)VARIABLE).Naam != "Kano")
                        {
                            budget = budget - 1*dagen;
                        }
                        if (meren >= 12)
                        {
                            break;
                        }
                    }
                    
                }
                meren = meren + 1;
            }
            return meren;

        }
    }
}

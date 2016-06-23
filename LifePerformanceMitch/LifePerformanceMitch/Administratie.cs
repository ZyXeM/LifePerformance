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
         /// <summary>
         /// Voet nieuw vaargebied toe aan database
         /// </summary>
         /// <param name="vaar"></param>
         /// <returns></returns>
        public static bool VoegMeerToe(Vaargebieden vaar)
        {
            if (Database.VoegMeerToe(vaar))
            {
                Update();
                return true;
            }
            return false;

        }
        /// <summary>
        /// Voegt nieuwe klant toe aan database
        /// </summary>
        /// <param name="klant"></param>
        /// <returns></returns>
        public static bool VoegKlantToe(Klant klant)
        {
            if (Database.VoegKlantToe(klant))
            {
                Update();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Geeft de hoeveelheid afstand die een boot kan reizen terug in KM
        /// </summary>
        /// <param name="boot"></param>
        /// <returns></returns>
        public static int KrijgActieRadius(Motorboot boot)
        {
            return boot.Tankinhoud*15;
        }
        /// <summary>
        /// Voegt een huurcontract toe aan de database
        /// </summary>
        /// <param name="huur"></param>
        /// <returns></returns>
        public static bool VoegHuurcontractToe(Huurcontract huur)
        {
            if (Database.VoegHuurcontractToe(huur))
            {
                Update();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Exporteert huurcontract naar een op te geven locatie
        /// </summary>
        /// <param name="huur"></param>
        /// <returns></returns>
        public static bool ExporteerHuurcontract(Huurcontract huur)
        {
            try
            {
               
                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "DefaultOutputName.txt";
                save.Filter = "Text File | *.txt";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter s = new StreamWriter(save.OpenFile());
                    s.WriteLine("Huurder : " + huur.Klant.Naam);
                    s.WriteLine("Huurcontract vanaf : " + huur.Datum_Vanaf);
                    s.WriteLine("Huurcontract tot : " + huur.Datum_Tot);
                    s.WriteLine("Artikelen :");
                    foreach (var h in huur.Huurlijst)
                    {
                        s.WriteLine("Verhuurde Item : " + h.Naam + " Prijs per dag : " + h.Huurprijs);
                    }


                    s.Close();
                }
                // If the file name is not an empty string open it for saving.
                    
                
                    // Saves the Image via a FileStream created by the OpenFile method.
                  
                   
                }
            catch (Exception)
            {
                return false;
            }
            return true;

            }
           
           
            
        

        public static List<int> BerekenGevoel(HuurcontractForm huur)
        {
            return new List<int>();
        }
        /// <summary>
        /// Opdate de locale lijsten
        /// </summary>
        public static void Update()
        {
            klanten = Database.KrijgKlanten();
            Contractlijst = Database.KrijgHuurcontracts();
            Vaargebieden = Database.KrijgVaargebiedens();
            Huurlijst = Database.KrijgHuurLijst();

        }
        /// <summary>
        /// Geeft terug hoeveel friese meren je kunt bevaren met een bepaald budget en een huidig contract + gebieden waar je extra wil varen
        /// </summary>
        /// <param name="huur"></param>
        /// <param name="budget"></param>
        /// <param name="vaar"></param>
        /// <returns></returns>
        public static int KrijgBevarenMeer(Huurcontract huur, decimal budget, List<Vaargebieden> vaar)
        {
            //Ik vraag eerst de dagen tussen de van en tot op en ga daar vervolgens mee rekenen
            int dagen = 0;
            int meren = 0;
            decimal Budget = budget;
            int overboot = 0;
          TimeSpan Lengte =  huur.Datum_Tot.Subtract(huur.Datum_Vanaf);
            dagen = Lengte.Days;
            if (dagen == 0)
            {
                dagen = 1;
            }
            // Eerst worden alle standaard kosten die je al moet betalen eraf gehaald
            foreach (var VARIABLE in vaar)
            {
                Budget = Budget - VARIABLE.Dagprijs*dagen;
                if (Budget < 0)
                {
                    throw new NotEnoughMoneyException("Te weinig geld");
                }
            }
            foreach (var VARIABLE in huur.Huurlijst)
            {
                Budget = Budget - VARIABLE.Huurprijs * dagen;
                if (Budget < 0)
                {
                    throw  new NotEnoughMoneyException("Te weinig geld");
                }
            }
            //Als Het budget nog niet leeg is word er geprobeerd voor elke boot 1 meer te laten bevaren
            while (Budget > 0)
            {
                int i = 0;
                int i2 = 0;
                foreach (var VARIABLE in huur.Huurlijst)
                {
                    if (VARIABLE is Boot)
                    {
                        i++;
                        //Alle niet Kanos hoeven geen sluisgeld dus moeten niet meegerekent worden i2 is dus alles behalve kano
                        if (VARIABLE.Naam != "Kano")
                        {
                            i2++;
                        }
                      
                    }
                    
                }
                //Als het budget niet leeg zou zijn dan word de aantal boten * de prijs * de dagen eraf gehaald en dan heb je 1 meer die te bevaren is
                if (Budget - 1 * dagen * i >= 0 && meren < 6 )
                {
                    Budget = Budget - 1 * dagen * i;
                    meren = meren + 1;
                }
                else if (Budget - (decimal) (1.50)*dagen*i2 >= 0 && meren > 5)
                {
                    Budget = Budget - (decimal) 1.50*dagen*i2;
                    meren = meren + 1;
                }
                else
                {
                    break;
                }
               
                if (meren >= 12)
                {
                    break;
                }
              
            }
            return meren;

        }
    }
}

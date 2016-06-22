using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Database.VoegMeerToe(vaar);
        }

        public static bool VoegKlantToe(Klant klant)
        {
            Database.VoegKlantToe(klant);
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
            
        }

        public static List<int> BerekenGevoel(Huurcontract huur)
        {
            return new List<int>();
        }

        public static void Update()
        {
            klanten = Database.KrijgKlanten();
            Contractlijst = Database.KrijfHuurcontracts();
            Vaargebieden = Database.KrijgVaargebiedens();

        }
    }
}

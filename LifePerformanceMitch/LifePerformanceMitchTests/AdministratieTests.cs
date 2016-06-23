using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifePerformanceMitch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifePerformanceMitch.Model;

namespace LifePerformanceMitch.Tests
{
    [TestClass()]
    public class AdministratieTests
    {
        [TestMethod()]
        public void VoegMeerToeTest()
        {
            Assert.AreEqual(Administratie.VoegMeerToe(new Vaargebieden(1,"Unit test", 3)),true);
        }

        [TestMethod()]
        public void VoegKlantToeTest()
        {
            Assert.AreEqual(Administratie.VoegKlantToe(new Klant("Mitch","Test")), true);
        }

        [TestMethod()]
        public void KrijgActieRadiusTest()
        {
            Assert.AreEqual(Administratie.KrijgActieRadius(new Motorboot("Motorsss",3,"Testboot",20)),300);
        }

        [TestMethod()]
        public void VoegHuurcontractToeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExporteerHuurcontractTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BerekenGevoelTest()
        {
            Assert.Fail();
        }

     

        [TestMethod()]
        public void KrijgBevarenMeerTest()
        {
            Assert.Fail();
        }
    }
}
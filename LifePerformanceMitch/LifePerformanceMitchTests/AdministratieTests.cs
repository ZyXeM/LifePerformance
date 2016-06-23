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
            List<Huur> huurs = new List<Huur>();
            huurs.Add(new Motorboot("Motorboot",15,"Kruiser",20));
            huurs.Add(new Artikel(1,1,"Zwemvest",1));
            Huurcontract huur = new Huurcontract(DateTime.Now, DateTime.Now.AddDays(2), huurs,new Klant(1,"Klant","KlantMail@mail"));
            Assert.AreEqual(Administratie.VoegHuurcontractToe(huur),true);
        }


    

     

        [TestMethod()]
        public void KrijgBevarenMeerTest()
        {
            List<Huur> huurl = new List<Huur>();
            huurl.Add(new Motorboot("Motor",10,"Type",5));
            Huurcontract huur = new Huurcontract(DateTime.Now, DateTime.Now.AddDays(5),huurl,new Klant("Mitch","Test") );
            Assert.AreEqual(Administratie.KrijgBevarenMeer(huur, 50, new List<Vaargebieden>()),0);
            huurl = new List<Huur>();
            huurl.Add(new Motorboot("Motor", 10, "Type", 5));
            huur = new Huurcontract(DateTime.Now, DateTime.Now.AddDays(5), huurl, new Klant("Mitch", "Test"));
            Assert.AreEqual(Administratie.KrijgBevarenMeer(huur, 60, new List<Vaargebieden>()), 2);
            //2 boten
            huurl.Clear();
            huurl.Add(new Motorboot("Motor", 10, "Type", 5));
            huurl.Add(new Motorboot("Motor", 10, "Type", 5));
            huur = new Huurcontract(DateTime.Now, DateTime.Now.AddDays(5), huurl, new Klant("Mitch", "Test"));
            Assert.AreEqual(Administratie.KrijgBevarenMeer(huur, 100, new List<Vaargebieden>()), 0);
        }
    }
}
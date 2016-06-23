using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LifePerformanceMitch.Model;

namespace LifePerformanceMitch
{
    public partial class HuurcontractForm : Form
    {
        public HuurcontractForm()
        {
            InitializeComponent();
            Administratie.Update();
            foreach (var VARIABLE in Administratie.Huurlijst)
            {
                if (VARIABLE is Boot)
                {
                    BootenLbx.Items.Add(VARIABLE);
                }
                if (VARIABLE is Artikel)
                {
                    ArtikelenLbx.Items.Add(VARIABLE);
                }
            }
            foreach (var VARIABLE in Administratie.klanten)
            {
                KlantCx.Items.Add(VARIABLE);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BootenLbx.SelectedIndex >= 0)
            {
                GekozenLbx.Items.Add(BootenLbx.SelectedItem);
            }
            //Toevoegen aan gekozen items
        }

        private void ArtikelenBtn_Click(object sender, EventArgs e)
        {
            if (ArtikelenLbx.SelectedIndex >= 0)
            {
                GekozenLbx.Items.Add(ArtikelenLbx.SelectedItem);
            }
            //Toevoegen aan gekozen items
        }

        private void ActieBtn_Click(object sender, EventArgs e)
        {
            if (BootenLbx.SelectedIndex >= 0)
            {
                //CHecked of de naam van het huurcontract voorkomt in de lijst en een motorboot is
                Motorboot huur =  BootenLbx.SelectedItem as Motorboot;  
              




                if (huur
                    != null)
                        
                {
                    //Berekent de actieradius met de motorboot uit de lijst
                    MessageBox.Show("Actieradius = " + Administratie.KrijgActieRadius(Administratie.Huurlijst.Find(m => m.Naam.Contains(((Huur)BootenLbx.SelectedItem).Naam)) as Motorboot));
                   ;
                }
            }

        }

        private void HuurcontractBtn_Click(object sender, EventArgs e)
        {
            List<Huur> list = new List<Huur>();
            foreach (var VARIABLE in GekozenLbx.Items)
            {
                list.Add(((Huur)VARIABLE));
            }
            if (TotDtp.Value.CompareTo(VanDtp.Value) > 0)
            {
                
                if (
                    Administratie.VoegHuurcontractToe(new Huurcontract(TotDtp.Value, VanDtp.Value, list,
                        (Klant) KlantCx.SelectedItem)))
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Datums Incorrect");
            }

        }
    }
}

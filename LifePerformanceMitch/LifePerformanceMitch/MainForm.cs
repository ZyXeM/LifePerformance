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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            if(HuurcontractLbx.SelectedIndex > 0)
            {
                if (Administratie.ExporteerHuurcontract((Huurcontract)HuurcontractLbx.SelectedItem))
                {
                    MessageBox.Show("Export geslaagd");
                }
            }
           
        }

        private void HuurcontractBtn_Click(object sender, EventArgs e)
        {
            HuurcontractForm huurcontract = new HuurcontractForm();
            
                huurcontract.ShowDialog();
            Administratie.Update();
            
        }

        private void KlantBtn_Click(object sender, EventArgs e)
        {
            if (NaamTb.Text != "" && EmailTb.Text != "")
            {
                Administratie.VoegKlantToe(new Klant(NaamTb.Text, EmailTb.Text));
            }
        }

        private void MeerBtn_Click(object sender, EventArgs e)
        {
            if (MeerNaamTbx.Text != "")
            {
                int i = 2;
                if (MotorChk.Checked)
                {
                    i = 1;
                }
                if (SpierChk.Checked)
                {
                    i = 0;
                }
                Administratie.VoegMeerToe(new Vaargebieden(PrijsNm.Value,MeerNaamTbx.Text,i));
            }
        }
    }
}

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
    public partial class BudgetForm : Form
    {
        public Huurcontract Huurcontract { get; set; }
        public BudgetForm(Huurcontract huurcontract)
        {
            InitializeComponent();
            Huurcontract = huurcontract;
            foreach (var VARIABLE in Administratie.Vaargebieden.FindAll(m => !m.Naam.Contains("Friese")))
            {
                listBox1.Items.Add(VARIABLE);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count > 0)
            {
                List<Vaargebieden> vaar = new List<Vaargebieden>();
                foreach (var v in listBox2.Items)
                {
                    vaar.Add(v as Vaargebieden);
                }
                Administratie.KrijgBevarenMeer(Huurcontract, BudgetNmrc.Value, vaar);
            }
        }
    }
}
